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
- bản trình bày
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây gián đoạn trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bản trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) lớp, phương thức, thuộc tính và các mục khác, bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) nào được giới thiệu cùng với API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Thêm Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), và các phương thức setOverlap(byte)**
Phương thức Aspose.Slides.Charts.IChartSeries.getOverlap() lấy giá trị cho biết các thanh và cột nên chồng lên nhau bao nhiêu trên biểu đồ 2D (trong khoảng từ -100 đến 100). Phương thức này không chỉ áp dụng cho một series cụ thể mà cho tất cả các series trong nhóm series cha – đây là sự chiếu của thuộc tính nhóm tương ứng.

- Sử dụng phương thức IChartSeries.getParentSeriesGroup() để truy cập vào nhóm series cha.
- Sử dụng các phương thức IChartSeriesGroup.getOverlap() và setOverlap(byte) để quản lý giá trị.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Thêm giá trị Enum ShapeThumbnailBounds.Appearance**
Phương pháp tạo thumbnail hình cho phép nhà phát triển tạo thumbnail hình trong giới hạn của sự xuất hiện của nó. Nó tính đến tất cả các hiệu ứng hình. Thumbnail hình được tạo sẽ bị giới hạn bởi giới hạn của slide.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Thêm lớp VbaProject và giao diện IVbaProject, thay đổi các phương thức Presentation.getVbaProject() và setVbaProject(VbaProject)**
Tính năng mới cho phép nhà phát triển tạo và chỉnh sửa các dự án VBA trong một bản trình bày.

``` java

 Presentation pres = new Presentation();

// Tạo dự án VBA mới
pres.setVbaProject(new VbaProject());

// Add empty module to the VBA project

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Set module source code

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Create reference to <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Create reference to Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Add references to the VBA project

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```