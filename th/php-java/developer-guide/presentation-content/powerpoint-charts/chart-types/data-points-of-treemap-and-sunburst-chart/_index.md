---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย PHP
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ ป้ายข้อความ และสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Treemap และ Sunburst แสดงข้อมูลเชิงลำดับชั้นแบบเดียวกัน แต่ใช้การจัดเรียงที่แตกต่างกัน Treemap แสดงลำดับชั้นเป็นสี่เหลี่ยมซ้อนกันโดยพื้นที่ของสี่เหลี่ยมแทนค่าของใบข้อมูล ส่วน Sunburst แสดงเป็นวงแหวนรอบศูนย์: กลุ่มระดับบนอยู่ใกล้ศูนย์และหมวดหมู่ใบข้อมูลอยู่บนวงแหวนด้านนอก

ใน Aspose.Slides for PHP via Java ค่าเชิงตัวเลขแต่ละค่าจะเป็น [ChartDataPoint](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/). วิธีการ [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) ให้เข้าถึงใบข้อมูลและกลุ่มแม่ของมัน บทความนี้อธิบายการแมปนี้และแสดงวิธีสร้างและกำหนดรูปแบบแผนภูมิทั้งสองประเภทจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap ที่มีสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst ที่มีลำดับชั้น Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีระดับหมวดหมู่สามระดับและชุดค่าตัวเลขหนึ่งชุด:

| สาขา | โครง | ใบ | รายได้ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งรายการและจุดข้อมูลหนึ่งรายการ ระดับการจัดกลุ่มหมวดหมู่อธิบายเส้นทางจากใบนั้นถึงกลุ่มแม่ของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`

ดัชนีที่ส่งคืนโดย [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) จะเริ่มจากใบข้อมูลและขึ้นไปด้านบน:

| `getDataPointLevels()` index | ระดับตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่าตัว | ส่วนวงแหวนด้านนอก |
| `1` | โครง | สี่เหลี่ยมพาเรนต์หรือหัวข้อ | ส่วนวงแหวนกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวข้อ | ส่วนวงแหวนด้านใน |

ลำดับนี้เหมือนกันสำหรับแผนภูมิทั้งสองประเภท แม้ว่าการจัดวางจะต่างกัน ส่วนของพาเรนต์จะถูกแชร์โดยหลายใบ เพื่อกำหนดรูปแบบให้ใช้ระดับที่สอดคล้องกับจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มต้นด้วยจุด `Laptops` ส่วนโครง `Software` เริ่มต้นด้วยจุด `Licenses` การเก็บอ้างอิงจุดเหล่านั้นทำให้โค้ดชัดเจนและปลอดภัยกว่าการใช้การแสดงผลที่ไม่อธิบายเช่น `$dataPoints->get_Item(0)` หรือ `$dataPoints->get_Item(6)`

## **สร้างและปรับแต่งแผนภูมิทั้งสองประเภท**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง มันสร้างลำดับชั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก กำหนดรูปแบบป้ายสาขา และบันทึกงานนำเสนอ

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // เพิ่มหมวดหมู่ใบข้อมูล. รายการจัดกลุ่มจะถูกตั้งค่าเฉพาะเมื่อกลุ่มใหม่เริ่มต้น;
        // หมวดหมู่ต่อไปนี้คงอยู่ในกลุ่มนั้นจนกว่ารายการอื่นจะถูกตั้งค่า.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // แสดงหมวดหมู่และค่าบนใบข้อมูล Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // กำหนดรูปแบบสาขา Consumer ผ่านใบข้อมูลแรกในสาขานั้น.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // กำหนดรูปแบบโครง Software ผ่านใบข้อมูลแรกในโครงนั้น.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout มีผลต่อป้ายพาเรนต์ของ Treemap; Sunburst ใช้ส่วนของวงแหวน.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เซลล์หมวดหมู่และเซลล์ค่าจะใช้แถว worksheet เดียวกัน ดังนั้นตำแหน่งของคอลเลกชันจึงยังคงตรงกัน เมื่อทำงานกับแผนภูมิที่มีอยู่แทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงที่ตั้งชื่อไว้สำหรับจุดข้อมูลและระดับที่ต้องการกำหนดรูปแบบ

## **พฤติกรรมและข้อพิจารณาการใช้งาน**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าตัวเลขและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับชั้น วิธีการ [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setParentLabelLayout) ควบคุมวิธีการแสดงป้ายพาเรนต์ในประเภทแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าตัวเลขและความลึกของวงแหวนเพื่อสื่อลำดับชั้น [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setParentLabelLayout) ไม่ควบคุมป้ายวงแหวนของมัน
- แผนภูมิทั้งสองใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบถึงพาเรนต์เดียวกันที่ส่งคืนโดย [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) ดังนั้นโค้ดการสร้างข้อมูลและการกำหนดรูปแบบระดับสามารถใช้ร่วมกันได้
- ค่าพาเรนต์จะคำนวณจากใบข้อมูลที่สืบทอด ไม่เพิ่มจุดตัวเลขแยกต่างหากสำหรับสาขาหรือโครง

### **การจัดเรียงและลำดับส่วน**

เครื่องยนต์การจัดวางแผนภูมิจัดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนวงแหวน จัดแถวหมวดหมู่ที่เกี่ยวข้องให้ต่อเนื่องก่อนเพิ่มลงไป แต่ไม่ควรอิงตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นใดเป็นพิเศษ หากลำดับมีความหมาย ให้ใส่ไว้ในป้ายหรือใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้กำหนดรูปแบบจะสืบทอดสีจากธีมงานนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อให้ผลลัพธ์คาดเดาได้ หากต้องการให้แผนภูมิตามการเปลี่ยนธีม ให้ใช้สีจากสคีมแทนค่า RGB คงที่และหลีกเลี่ยงการเขียนทับทุกระดับ ตรวจสอบความคอนทราสต์ของป้ายหลังเปลี่ยนสีสาขาหรือโครง

### **ป้ายและพื้นที่ว่างที่ใช้ได้**

PowerPoint อาจซ่อนหรือตัดทอนป้ายเมื่อส่วนมีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ การย่อชื่อหมวดหมู่ หรือแสดงฟิลด์ป้ายให้น้อยลงมักทำให้ผลลัพธ์ชัดเจนขึ้น ป้ายสามารถรวมชื่อหมวดหมู่, ชื่อชุด, และค่าได้ผ่าน [DataLabelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabelformat/) แต่การเปิดใช้งานทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการแสดงผล**

การบันทึกเป็น PPTX ทำให้แผนภูมิแก้ไขได้ เมื่อ Aspose.Slides แสดงผลงานนำเสนอเป็น PDF หรือรูปภาพ การเติมสีและการตั้งค่าป้ายที่รองรับจะถูกรวมในการแสดงผล การแทนที่ฟอนท์และความแตกต่างเล็กน้อยของพื้นที่จัดวางที่ใช้ได้อาจทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนแปลง ดังนั้นให้ติดตั้งฟอนท์ที่ต้องการและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับพาเรนต์ถึงส่งผลต่อหลายใบ?**

สาขาหรือโครงเป็นส่วนภาพที่แชร์กัน การเข้าถึง [ChartDataPointLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/) ทำได้ผ่านใบข้อมูลที่สืบทอด แต่การกำหนดรูปแบบเป็นของส่วนพาเรนต์ที่แชร์ ไม่ได้เป็นของใบเดียวเท่านั้น

**ทำไมป้ายข้อมูลถึงหายไป?**

ให้เปิดใช้งานฟิลด์ที่ต้องการบนวัตถุ [DataLabelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabelformat/) ก่อน จากนั้นตรวจสอบว่ามีพื้นที่เพียงพอสำหรับส่วนหรือไม่ การจัดวางป้ายพาเรนต์ของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนท์, และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดมีผลต่อการแสดงป้ายหรือไม่

**ฉันสามารถกำหนดลำดับหรือพิกัดของส่วนอย่างแม่นยำได้หรือไม่?**

คุณสามารถควบคุมลำดับแถวต้นฉบับและทำให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องยนต์การจัดวางแผนภูมิคำนวณจากลำดับชั้น, ค่าตัวเลข, และพื้นที่ว่างที่มี

**ทำไมสีจึงเปลี่ยนหลังจากธีมงานนำเสนอเปลี่ยน?**

การเติมสีตามธีมออกแบบมาให้ตามพาเล็ตของงานนำเสนอ ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องการคงที่ หรือคงสีจากสคีมเมื่อการปรับให้เข้ากับธีมใหม่เป็นที่ต้องการ

**การกำหนดรูปแบบที่กำหนดเองจะคงอยู่ใน PDF และการส่งออกรูปภาพหรือไม่?**

ใช่ การเติมสีแผนภูมิและการตั้งค่าป้ายที่รองรับจะถูกรวมในการแสดงผล เพื่อผลลัพธ์สม่ำเสมอข้ามระบบ ให้ทำให้ฟอนท์ที่จำเป็นพร้อมใช้งานและทดสอบขนาดการส่งออกสุดท้าย เพราะการปรับขนาดป้ายขึ้นอยู่กับการจัดวาง

## **ดูเพิ่มเติม**

- [Create Treemap charts](/slides/th/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/th/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/th/php-java/export-chart/)
- [Manage presentation themes](/slides/th/php-java/presentation-theme/)