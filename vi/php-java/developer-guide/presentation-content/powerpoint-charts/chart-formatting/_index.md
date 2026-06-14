---
title: Định dạng biểu đồ trong bản thuyết trình bằng PHP
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/php-java/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho PHP thông qua Java và nâng cao bản thuyết trình PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong các bản thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các yếu tố chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện vẻ ngoài và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật góc bo tròn cho khu vực biểu đồ. Các ví dụ này cùng nhau cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong một bản thuyết trình.

## **Định dạng các thực thể biểu đồ**
Aspose.Slides for PHP via Java cho phép các nhà phát triển thêm biểu đồ tùy chỉnh vào slide từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị của biểu đồ.

Aspose.Slides for PHP via Java cung cấp một API đơn giản để quản lý các thực thể biểu đồ khác nhau và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp [**Presentation**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (trong ví dụ này chúng ta sẽ sử dụng ChartType::LineWithMarkers).
1. Truy cập trục Giá trị của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của trục Giá trị
   1. Đặt **Line format** cho các đường lưới phụ của trục Giá trị
   1. Đặt **Number Format** cho trục Giá trị
   1. Đặt **Min, Max, Major and Minor units** cho trục Giá trị
   1. Đặt **Text Properties** cho dữ liệu trục Giá trị
   1. Đặt **Title** cho trục Giá trị
   1. Đặt **Line Format** cho trục Giá trị
1. Truy cập trục Danh mục của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của trục Danh mục
   1. Đặt **Line format** cho các đường lưới phụ của trục Danh mục
   1. Đặt **Text Properties** cho dữ liệu trục Danh mục
   1. Đặt **Title** cho trục Danh mục
   1. Đặt **Label Positioning** cho trục Danh mục
   1. Đặt **Rotation Angle** cho nhãn trục Danh mục
1. Truy cập chú giải của biểu đồ và đặt **Text Properties** cho chúng
1. Hiển thị chú giải biểu đồ mà không bị chồng lấn lên biểu đồ
1. Truy cập **Secondary Value Axis** của biểu đồ và đặt các thuộc tính sau:
   1. Kích hoạt **Secondary Value Axis**
   1. Đặt **Line Format** cho Secondary Value Axis
   1. Đặt **Number Format** cho Secondary Value Axis
   1. Đặt **Min, Max, Major and Minor units** cho Secondary Value Axis
1. Bây giờ vẽ chuỗi biểu đồ đầu tiên trên Secondary Value Axis
1. Đặt màu nền tường sau của biểu đồ
1. Đặt màu nền khu vực vẽ của biểu đồ
1. Ghi bản thuyết trình đã chỉnh sửa vào tệp PPTX

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm biểu đồ mẫu
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Đặt tiêu đề biểu đồ
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Đặt định dạng đường lưới chính cho trục giá trị
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Đặt định dạng đường lưới phụ cho trục giá trị
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Đặt định dạng số cho trục giá trị
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Đặt giá trị tối đa, tối thiểu cho biểu đồ
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Đặt thuộc tính văn bản cho trục giá trị
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Đặt tiêu đề trục giá trị
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Đặt định dạng đường lưới chính cho trục Danh mục
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Đặt định dạng đường lưới phụ cho trục Danh mục
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Đặt thuộc tính văn bản cho trục Danh mục
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Đặt tiêu đề Danh mục
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Đặt vị trí nhãn trục Danh mục
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Đặt góc xoay nhãn trục Danh mục
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Đặt thuộc tính văn bản cho chú giải
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Hiển thị chú giải biểu đồ mà không chồng lên biểu đồ
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Đặt trục giá trị phụ
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Đặt định dạng số cho trục giá trị phụ
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Đặt giá trị tối đa, tối thiểu cho biểu đồ
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Đặt màu tường sau của biểu đồ
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Đặt màu khu vực vẽ
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Lưu bản thuyết trình
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt thuộc tính phông chữ cho biểu đồ**
Aspose.Slides for PHP via Java hỗ trợ việc đặt các thuộc tính liên quan đến phông chữ cho biểu đồ. Vui lòng làm theo các bước dưới đây để đặt thuộc tính phông chữ cho biểu đồ.

- Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
- Thêm biểu đồ vào slide.
- Đặt chiều cao phông chữ.
- Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt định dạng số**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
1. Lấy tham chiếu tới một slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng **ChartType::ClusteredColumn**).
1. Đặt định dạng số có sẵn từ các giá trị đã định sẵn.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt định dạng số cho dữ liệu biểu đồ.
1. Lưu bản thuyết trình.
1. Đặt định dạng số tùy chỉnh.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi và đặt định dạng số khác nhau cho dữ liệu biểu đồ.
1. Lưu bản thuyết trình.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên của bản thuyết trình
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một biểu đồ cột nhóm mặc định
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Truy cập bộ sưu tập chuỗi biểu đồ
    $series = $chart->getChartData()->getSeries();
    # Duyệt qua mỗi chuỗi biểu đồ
    foreach($series as $ser) {
      # Duyệt qua mỗi ô dữ liệu trong chuỗi
      foreach($ser->getDataPoints() as $cell) {
        # Đặt định dạng số
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Lưu bản thuyết trình
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Các giá trị định dạng số có sẵn cùng với chỉ số của chúng có thể được sử dụng được liệt kê dưới đây:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt viền bo tròn cho khu vực biểu đồ**
Aspose.Slides for PHP via Java hỗ trợ việc đặt khu vực biểu đồ. Các phương pháp [**hasRoundedCorners**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/hasroundedcorners/) và [**setRoundedCorners**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setroundedcorners/) đã được thêm vào lớp [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Chart) .

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
1. Thêm biểu đồ vào slide.
1. Đặt loại và màu nền cho biểu đồ
1. Đặt thuộc tính góc bo tròn là True.
1. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra. 

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho cột/khu vực đồng thời giữ viền không trong suốt không?**

Có. Độ trong suốt của nền và viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm thế nào để xử lý nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không thiết yếu (ví dụ, danh mục), đặt độ lệch/định vị nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang “giá trị + chú giải”.

**Tôi có thể áp dụng màu nền gradient hoặc họa tiết cho chuỗi dữ liệu không?**

Có. Cả màu nền đặc và gradient/họa tiết thường đều khả dụng. Trong thực tế, nên sử dụng gradient một cách tiết kiệm và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.