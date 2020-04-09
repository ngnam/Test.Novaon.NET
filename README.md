# Test.Novaon.NET

### Bài 1: Website (Backend + Fontend)
Tạo Project sử dụng ASP.Net MVC5, Bootstrap, jQuery, Ajax, HTML5, CSS, Entity Framework 6, SQL Server 
Các chức năng bao gồm:
1.	Form đăng ký và đăng nhập.
2.	Responsive trên thiết bị mobi và desktop
3.	Lưu thông tin người dùng trên sql server, mật khẩu phải được mã hóa sử dụng MD5 hash
4.	Validate thông tin email: kiểm tra tồn tại, định dạng email
5.	Validate thông tin mật khẩu: phải là ký tự a->z, 0->9, có ít nhất 1 chữ hoa, chữ thường, trong khoảng 6->12 ký tự.
6.	Lưu thông tin đăng nhập trên cookie và session bao gồm full thông tin của user, thời gian timeout của session là 30p. Sau khi đăng nhập thành công sẽ chuyển đến trang thông báo đăng nhập thành công (Giao diện tùy ý).
Giao diện tự sáng tạo đi :)
 
### Bài 2: (SQL) 
# [sql-novaon](https://github.com/ngnam/sql-novaon)
Lưu toàn bộ các script tạo database, table, insert data, update data
1.	Tạo các bảng và thêm dữ liệu 
* a.	Bảng Product: Lưu dữ các sản phẩm của website bao gồm
* i.	Tên sản phẩm
* ii.	Nhóm sản phẩm
* iii.	Đơn giá
* iv.	Các thông tin khác (tùy ý)

* b.	Bảng Orders: Lưu các thông tin liên quan đến đơn hàng do khách hàng đặt:

* i.	Ngày đặt

* ii.	Tổng tiền

* iii.	Mã khách hàng

* iv.	Các thông tin cần thiết khác (tùy ý)

* c.	Bảng OrderDetail: Lưu chi tiết thông tin sản phẩm khách hàng đặt mua

* i.	Mã sản phẩm đặt

* ii.	Số lượng

* iii.	Đơn giá

* iv.	Các thông tin cần thiết khác (tùy ý)

* d.	Insert dữ liệu giả lập cho các bảng Product, Orders, OrderDetail (Mỗi bảng khoảng 10 bản ghi)

2.	 Viết script để lấy dữ liệu như sau:

* a. Thống kê tất cả các sản phẩm đã được bán, sắp xếp theo thứ tự từ bán nhiều đến ít

* b. Thống kê ra toàn bộ các sản phẩm chưa từng được bán ra

* c. Thêm cột Vat vào bảng Orders

* d. Cập nhật dữ liệu cho cột Vat, theo công thức Vat = 10% của Tổng tiền, làm tròn đến 2 số sau số 0.
