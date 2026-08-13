---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.8.0
linktitle: Aspose.Slides cho Java 14.8.0
type: docs
weight: 70
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các phần khác đã được [đã thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), bất kỳ hạn chế mới nào và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) được giới thiệu trong API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Thêm các phương thức Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), và setOverlap(byte)**
Phương thức Aspose.Slides.Charts.IChartSeries.getOverlap() lấy giá trị cho biết các thanh và cột nên chồng lên nhau bao nhiêu trên biểu đồ 2D (trong khoảng từ -100 đến 100). Phương thức này không chỉ áp dụng cho một series cụ thể mà cho tất cả các series của nhóm series cha - đây là việc chiếu thuộc tính nhóm thích hợp.

- Sử dụng phương thức IChartSeries.getParentSeriesGroup() để truy cập vào nhóm series cha.
- Sử dụng các phương thức IChartSeriesGroup.getOverlap() và setOverlap(byte) để quản lý giá trị.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Thêm giá trị Enum ShapeThumbnailBounds.Appearance**
Phương thức tạo thumbnail hình dạng này cho phép nhà phát triển tạo thumbnail hình dạng trong giới hạn của giao diện của nó. Nó tính đến tất cả các hiệu ứng hình dạng. Thumbnail hình dạng được tạo ra bị giới hạn bởi giới hạn của slide.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Thêm lớp VbaProject và giao diện IVbaProject, thay đổi các phương thức Presentation.getVbaProject() và setVbaProject(VbaProject)**
Tính năng mới cho phép nhà phát triển tạo và chỉnh sửa dự án VBA trong một bản trình chiếu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Tạo dự án VBA mới

pres.setVbaProject(new VbaProject());

// Thêm mô-đun trống vào dự án VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Đặt mã nguồn cho mô-đun

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Tạo tham chiếu đến <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Tạo tham chiếu đến Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Thêm các tham chiếu vào dự án VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```