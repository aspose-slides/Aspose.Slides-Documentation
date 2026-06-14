---
title: Tạo hoạt ảnh cho biểu đồ PowerPoint trong Python
linktitle: Biểu đồ hoạt ảnh
type: docs
weight: 80
url: /vi/python-net/animated-charts/
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
- bản thuyết trình
- Python
- Aspose.Slides
description: "Tạo các biểu đồ hoạt ảnh ấn tượng trong Python với Aspose.Slides. Nâng cao bản thuyết trình với hình ảnh động trong các tệp PPT, PPTX và ODP — bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET hỗ trợ việc tạo hoạt ảnh cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được tạo hoạt ảnh bằng phương thức [ISequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/isequence/) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **Hoạt ảnh chuỗi biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một chuỗi biểu đồ, hãy viết mã theo các bước sau:

1. Tải một bản thuyết trình.  
1. Lấy tham chiếu đến đối tượng biểu đồ.  
1. Tạo hoạt ảnh cho chuỗi.  
1. Ghi tệp bản thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho chuỗi biểu đồ.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Tạo đối tượng Presentation đại diện cho tệp bản thuyết trình 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Lấy tham chiếu đến đối tượng biểu đồ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Tạo hoạt ảnh cho chuỗi
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Ghi bản thuyết trình đã chỉnh sửa ra đĩa 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoạt ảnh danh mục biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một danh mục biểu đồ, hãy viết mã theo các bước sau:

1. Tải một bản thuyết trình.  
1. Lấy tham chiếu đến đối tượng biểu đồ.  
1. Tạo hoạt ảnh cho danh mục.  
1. Ghi tệp bản thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho danh mục biểu đồ.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Lấy tham chiếu đến đối tượng biểu đồ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Tạo hoạt ảnh cho các phần tử danh mục
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Ghi tệp bản thuyết trình ra đĩa
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoạt ảnh trong phần tử chuỗi**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử chuỗi, hãy viết mã theo các bước sau:

1. Tải một bản thuyết trình.  
1. Lấy tham chiếu đến đối tượng biểu đồ.  
1. Tạo hoạt ảnh cho các phần tử chuỗi.  
1. Ghi tệp bản thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử của chuỗi.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Tải một bản thuyết trình
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Lấy tham chiếu đến đối tượng biểu đồ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Tạo hoạt ảnh cho các phần tử chuỗi
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Ghi tệp bản thuyết trình ra đĩa 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoạt ảnh trong phần tử danh mục**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử danh mục, hãy viết mã theo các bước sau:

1. Tải một bản thuyết trình.  
1. Lấy tham chiếu đến đối tượng biểu đồ.  
1. Tạo hoạt ảnh cho các phần tử danh mục.  
1. Ghi tệp bản thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử danh mục.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Lấy tham chiếu đến đối tượng biểu đồ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Tạo hoạt ảnh cho các phần tử danh mục
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Ghi tệp bản thuyết trình ra đĩa
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Các loại hiệu ứng khác nhau (ví dụ: entrance, emphasis, exit) có hỗ trợ cho biểu đồ giống như các hình dạng thông thường không?**  
Có. Một biểu đồ được coi là một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm entrance, emphasis và exit, với khả năng kiểm soát đầy đủ qua timeline và chuỗi hoạt ảnh của slide.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển đổi slide không?**  
Có. [Chuyển đổi](/slides/vi/python-net/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai cùng nhau trong cùng một bản thuyết trình và kiểm soát chúng độc lập.

**Các hoạt ảnh biểu đồ có được giữ lại khi lưu dưới dạng PPTX không?**  
Có. Khi bạn [lưu thành PPTX](/slides/vi/python-net/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ lại vì chúng là một phần của mô hình hoạt ảnh gốc của bản thuyết trình.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản thuyết trình và chỉnh sửa chúng không?**  
Có. [API](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/) cung cấp quyền truy cập vào timeline slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại từ đầu.

**Tôi có thể tạo video bao gồm các hoạt ảnh biểu đồ bằng Aspose.Slides for Python via .NET không?**  
Có. Bạn có thể [xuất bản thuyết trình thành video](/slides/vi/python-net/convert-powerpoint-to-video/) trong khi giữ nguyên hoạt ảnh, cấu hình thời gian và các thiết lập xuất khác để đoạn video cuối cùng phản ánh đúng quá trình phát hoạt ảnh.