---
title: API Công cộng và Các Thay đổi Không Tương thích Ngược trong Aspose.Slides cho .NET 14.4.0
linktitle: Aspose.Slides cho .NET 14.4.0
type: docs
weight: 60
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây gián đoạn trong Aspose.Slides cho .NET để di chuyển thuận lợi các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
## **API Công cộng và các Thay đổi không tương thích ngược**
### **Các giao diện, lớp, phương thức và thuộc tính được thêm**
#### **Thuộc tính Aspose.Slides.ILayoutSlide.HasDependingSlides đã được thêm**
Thuộc tính Aspose.Slides.ILayoutSlide.HasDependingSlides trả về true nếu tồn tại ít nhất một slide phụ thuộc vào slide bố cục này. Ví dụ:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Phương thức Aspose.Slides.ILayoutSlide.Remove()**
Phương thức Aspose.Slides.ILayoutSlide.Remove() cho phép bạn xóa một bố cục khỏi bài thuyết trình với tối thiểu mã. Ví dụ:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Phương thức Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Phương thức Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) cho phép bạn xóa một bố cục khỏi bộ sưu tập. Ví dụ mã:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

hoặc

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Phương thức Aspose.Slides.ILayoutSlideCollection.RemoveUnused() cho phép bạn xóa các slide bố cục không được sử dụng (các slide bố cục có HasDependingSlides là false). Ví dụ mã:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

hoặc

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Thuộc tính Aspose.Slides.IMasterSlide.HasDependingSlides**
Thuộc tính Aspose.Slides.IMasterSlide.HasDependingSlides trả về true nếu tồn tại ít nhất một slide phụ thuộc vào slide master này. Ví dụ:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Phương thức Aspose.Slides.ISlide.Remove()**
Phương thức Aspose.Slides.ISlide.Remove() cho phép bạn xóa một slide khỏi bài thuyết trình với tối thiểu mã. Ví dụ:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Thuộc tính Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat trả về IFillFormat cho dấu đầu dòng của nút SmartArt nếu bố cục cung cấp dấu đầu dòng. Nó có thể được sử dụng để đặt hình ảnh dấu đầu dòng.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level Property**
Thuộc tính Aspose.Slides.SmartArt.ISmartArtNode.Level trả về mức lồng nhau cho các nút SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position Property**
Thuộc tính Aspose.Slides.SmartArt.ISmartArtNode.Position trả về vị trí của một nút trong số các nút cùng cấp.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Phương thức Aspose.Slides.SmartArt.ISmartArtNode.Remove() đã được thêm**
Phương thức Aspose.Slides.SmartArt.ISmartArtNode.Remove() cho phép xóa một nút khỏi sơ đồ.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Giao diện IGlobalLayoutSlideCollection và Lớp GlobalLayoutSlideCollection**
Giao diện IGlobalLayoutSlideCollection và lớp GlobalLayoutSlideCollection đã được thêm vào không gian tên Aspose.Slides.

Lớp GlobalLayoutSlideCollection triển khai giao diện IGlobalLayoutSlideCollection.

Giao diện IGlobalLayoutSlideCollection đại diện cho một bộ sưu tập của tất cả các slide bố cục trong một bài thuyết trình. Thuộc tính IPresentation.LayoutSlides có kiểu IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection mở rộng giao diện ILayoutSlideCollection với các phương pháp thêm và sao chép slide bố cục trong ngữ cảnh hợp nhất các bộ sưu tập riêng lẻ của các slide bố cục của master:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Có thể được sử dụng để thêm một bản sao của một slide bố cục đã chỉ định vào bài thuyết trình. Phương pháp này giữ định dạng nguồn (khi sao chép bố cục giữa các bài thuyết trình khác nhau, master của bố cục cũng có thể được sao chép. Registry nội bộ được sử dụng để theo dõi các master được sao chép tự động nhằm ngăn việc tạo nhiều bản sao của cùng một master slide.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Được dùng để thêm một bản sao của một slide bố cục đã chỉ định vào một bài thuyết trình. Bố cục mới sẽ được liên kết với master đã định nghĩa trong bài thuyết trình đích. Tùy chọn này tương tự việc sao chép hoặc dán với tùy chọn **Use Destination Theme** trong Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Được dùng để thêm một slide bố cục mới vào một bài thuyết trình. Các loại bố cục được hỗ trợ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Tên bố cục có thể được tạo tự động. Một bố cục được thêm có kiểu SlideLayoutType.Custom không chứa placeholder và không có hình dạng. Tương đương của phương pháp này là phương pháp IMasterLayoutSlideCollection.Add(SlideLayoutType, string) được truy cập qua thuộc tính IMasterSlide.LayoutSlides.
#### **Giao diện IMasterLayoutSlideCollection và Lớp MasterLayoutSlideCollection**
Giao diện IMasterLayoutSlideCollection và lớp MasterLayoutSlideCollection đã được thêm vào không gian tên Aspose.Slides. Lớp MasterLayoutSlideCollection triển khai giao diện IMasterLayoutSlideCollection.

Giao diện IMasterLayoutSlideCollection đại diện cho một bộ sưu tập của tất cả các slide bố cục của một master slide đã định nghĩa. Nó mở rộng giao diện ILayoutSlideCollection với các phương pháp thêm, chèn, xóa hoặc sao chép slide bố cục trong ngữ cảnh của các bộ sưu tập riêng lẻ của các slide bố cục của master:

``` csharp

 // Chữ ký phương thức:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Ví dụ mã gắn bản sao của sourceLayout vào destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Phương pháp này có thể được dùng để thêm một bản sao của một slide bố cục đã chỉ định vào cuối bộ sưu tập. Bố cục mới sẽ được liên kết với master slide cha cho bộ sưu tập các slide bố cục này. Vì vậy đây là tương đương với việc sao chép hoặc dán với tùy chọn **Use Destination Theme** trong PowerPoint. Tương đương của phương pháp này là phương pháp IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) được truy cập qua thuộc tính IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Được dùng để chèn một bản sao của một slide bố cục đã chỉ định vào vị trí xác định của bộ sưu tập. Bố cục mới sẽ được liên kết với master slide cha cho bộ sưu tập các slide bố cục này. Vì vậy đây là tương đương với việc sao chép và dán với tùy chọn **Use Destination Theme** trong PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Được dùng để thêm hoặc chèn một slide bố cục mới. Các loại bố cục được hỗ trợ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Tên bố cục có thể được tạo tự động. Bố cục được thêm có kiểu SlideLayoutType.Custom không chứa placeholder và không có hình dạng. Tương đương của phương pháp này là phương pháp IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) được truy cập qua thuộc tính IPresentation.LayoutSlides.
- void RemoveAt(int index); – Được dùng để xóa bố cục tại vị trí chỉ định trong bộ sưu tập.
- void Reorder(int index, ILayoutSlide layoutSlide); – Được dùng để di chuyển slide bố cục trong bộ sưu tập tới vị trí chỉ định.
### **Các phương pháp và thuộc tính đã thay đổi**
#### **Chữ ký của phương pháp Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Chữ ký của phương pháp ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

đã lỗi thời và được thay thế bằng chữ ký

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Tham số allowCloneMissingLayout chỉ định hành động khi không có bố cục phù hợp trong destMaster cho slide mới (được sao chép). Bố cục phù hợp là bố cục có cùng loại hoặc tên với bố cục của slide nguồn. Nếu không có bố cục phù hợp trong master đã chỉ định thì bố cục của slide nguồn sẽ được sao chép (nếu allowCloneMissingLayout là true) hoặc sẽ ném ra một ngoại lệ PptxEditException (nếu allowCloneMissingLayout là false).

Gọi phương pháp lỗi thời như

AddClone(sourceSlide, destMaster);

giả sử allowCloneMissingLayout bằng false (tức là sẽ ném PptxEditException nếu không có bố cục phù hợp). Lời gọi tương đương sử dụng chữ ký mới như sau:
AddClone(sourceSlide, destMaster, false);

Nếu bạn muốn các bố cục thiếu tự động được sao chép thay vì ném PptxEditException thì truyền tham số allowCloneMissingLayout là true.

Điều tương tự áp dụng cho phương pháp ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

cũng đã lỗi thời và được thay thế bằng chữ ký

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Kiểu của thuộc tính Aspose.Slides.IMasterSlide.LayoutSlides**
Kiểu của thuộc tính Aspose.Slides.IMasterSlide.LayoutSlides đã được thay đổi từ ILayoutSlideCollection sang giao diện mới IMasterLayoutSlideCollection. Giao diện IMasterLayoutSlideCollection là một kế thừa của ILayoutSlideCollection nên mã hiện có không cần điều chỉnh.
#### **Kiểu của thuộc tính Aspose.Slides.IPresentation.LayoutSlides đã được thay đổi**
Kiểu của thuộc tính Aspose.Slides.IPresentation.LayoutSlides đã được thay đổi từ ILayoutSlideCollection sang giao diện mới IGlobalLayoutSlideCollection. Giao diện IGlobalLayoutSlideCollection là một kế thừa của ILayoutSlideCollection nên mã hiện có không cần điều chỉnh.