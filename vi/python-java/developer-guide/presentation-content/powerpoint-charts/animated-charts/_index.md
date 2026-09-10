---
title: Tạo hoạt ảnh cho biểu đồ PowerPoint trong Python qua Java
linktitle: Biểu đồ động
type: docs
weight: 80
url: /vi/python-java/animated-charts/
keywords:
- biểu đồ
- biểu đồ động
- hoạt ảnh biểu đồ
- chuỗi biểu đồ
- danh mục biểu đồ
- phần tử chuỗi
- phần tử danh mục
- thêm hiệu ứng
- loại hiệu ứng
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo các biểu đồ động ấn tượng trong Python qua Java với Aspose.Slides. Nâng cao bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX—bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides for Python via Java hỗ trợ việc tạo hoạt ảnh cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, và **Category Elements** có thể được tạo hoạt ảnh bằng cách sử dụng phương thức [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) và hai kiểu liệt kê: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effectchartmajorgroupingtype/) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Hoạt ảnh Chuỗi Biểu đồ**

Nếu bạn muốn tạo hoạt ảnh cho một chuỗi biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Ví dụ sau tạo hoạt ảnh cho các chuỗi biểu đồ. Biểu đồ trong tệp ví dụ có ba chuỗi, vì vậy một hiệu ứng được thêm cho mỗi chỉ số từ 0 đến 2. Aspose.Slides không kiểm tra chỉ số so với dữ liệu biểu đồ, và một hiệu ứng được thêm cho một chuỗi không tồn tại sẽ được ghi vào tệp nhưng không tạo hoạt ảnh gì—giữ chỉ số dưới số lượng chuỗi trong biểu đồ của bạn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Tải bản trình chiếu.
presentation = Presentation("ExistingChart.pptx")
try:
    # Lấy tham chiếu tới đối tượng biểu đồ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Tạo hoạt ảnh cho các thành phần biểu đồ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hoạt ảnh Danh mục Biểu đồ**

Nếu bạn muốn tạo hoạt ảnh cho một danh mục biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Ví dụ sau tạo hoạt ảnh cho các danh mục biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Tải bản trình chiếu.
presentation = Presentation("ExistingChart.pptx")
try:
    # Lấy tham chiếu tới đối tượng biểu đồ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Tạo hoạt ảnh cho các thành phần biểu đồ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hoạt ảnh trong Phần tử Chuỗi**

Nếu bạn muốn tạo hoạt ảnh cho các phần tử chuỗi, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Ví dụ sau tạo hoạt ảnh cho các phần tử chuỗi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Tải bản trình chiếu.
presentation = Presentation("ExistingChart.pptx")
try:
    # Lấy tham chiếu tới đối tượng biểu đồ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Tạo hoạt ảnh cho các thành phần biểu đồ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hoạt ảnh trong Phần tử Danh mục**

Nếu bạn muốn tạo hoạt ảnh cho các phần tử danh mục, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Ví dụ sau tạo hoạt ảnh cho các phần tử danh mục.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Tải bản trình chiếu.
presentation = Presentation("ExistingChart.pptx")
try:
    # Lấy tham chiếu tới đối tượng biểu đồ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Tạo hoạt ảnh cho các thành phần biểu đồ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các loại hiệu ứng khác nhau (ví dụ: vào, nhấn mạnh, ra) có được hỗ trợ cho biểu đồ giống như các hình dạng thông thường không?**

Có. Biểu đồ được coi như một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm vào, nhấn mạnh và ra, với khả năng kiểm soát đầy đủ qua thời gian biểu slide và các chuỗi hoạt ảnh.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển đổi slide không?**

Có. [Transitions](/slides/vi/python-java/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai cùng nhau trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt ảnh biểu đồ có được giữ lại khi lưu dưới dạng PPTX không?**

Có. Khi bạn [save to PPTX](/slides/vi/python-java/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ lại vì chúng là một phần của mô hình hoạt ảnh gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản trình chiếu và chỉnh sửa chúng không?**

Có. API cung cấp quyền truy cập vào thời gian biểu slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại toàn bộ từ đầu.

**Tôi có thể tạo video bao gồm các hoạt ảnh biểu đồ bằng Aspose.Slides không?**

Có. Bạn có thể [export a presentation to video](/slides/vi/python-java/convert-powerpoint-to-video/) trong khi giữ lại các hoạt ảnh, cấu hình thời gian và các thiết lập xuất khác để đoạn video kết quả phản ánh việc phát lại có hoạt ảnh.