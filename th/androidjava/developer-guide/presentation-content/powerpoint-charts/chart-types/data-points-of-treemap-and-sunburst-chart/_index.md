---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst บน Android
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ Treemap
- แผนภูมิ Sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ, ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ Android ผ่าน Java.
---
## **ภาพรวม**

แผนภูมิ Treemap และ Sunburst แสดงข้อมูลเชิงลำดับชั้นชนิดเดียวกัน แต่ใช้การจัดวางที่แตกต่างกัน Treemap แสดงลำดับชั้นเป็นสี่เหลี่ยมซ้อนกันโดยพื้นที่ของสี่เหลี่ยมแทนค่าของใบข้อมูล Sunburst แสดงเป็นวงในศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์และหมวดหมู่ใบอยู่บนวงรอบนอก

ใน Aspose.Slides สำหรับ Android ผ่าน Java แต่ละค่าตัวเลขเป็น [IChartDataPoint](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/). วิธีการ [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) ให้เข้าถึงใบข้อมูลและกลุ่มพ่อแม่ของมัน บทความนี้อธิบายการแมปนี้และแสดงวิธีสร้างและกำหนดรูปแบบแผนภูมิทั้งสองประเภทจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap ที่มีสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst ที่มีสาขา Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีสามระดับหมวดหมู่และชุดตัวเลขหนึ่งชุด:

| สาขา | โคน | ใบ | รายได้ |
| --- | --- | --- | ---: |
| ผู้บริโภค | คอมพิวเตอร์ | แล็ปท็อป | 12 |
| ผู้บริโภค | คอมพิวเตอร์ | เดสก์ท็อป | 8 |
| ผู้บริโภค | มือถือ | โทรศัพท์ | 15 |
| ผู้บริโภค | มือถือ | แท็บเล็ต | 6 |
| ธุรกิจ | บริการ | การให้คำปรึกษา | 10 |
| ธุรกิจ | บริการ | สนับสนุน | 7 |
| ธุรกิจ | ซอฟต์แวร์ | ไลเซนส์ | 11 |
| ธุรกิจ | ซอฟต์แวร์ | การสมัครสมาชิก | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งรายการและจุดข้อมูลหนึ่งรายการ ระดับการจัดกลุ่มหมวดหมู่อธิบายเส้นทางจากใบนั้นไปยังพ่อแม่ของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`.

ดัชนีที่ส่งกลับโดย [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) จะเริ่มจากใบแล้วไปขึ้นด้านบน:

| ดัชนี `getDataPointLevels()` | ระดับเชิงตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่า | เซกเมนต์วงนอก |
| `1` | โคน | สี่เหลี่ยมพ่อแม่หรือหัวส่วน | เซกเมนต์วงกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวส่วน | เซกเมนต์วงใน |

ลำดับนี้เหมือนกันสำหรับแผนภูมิทั้งสองประเภทแม้ว่าการจัดวางภาพจะแตกต่างกัน เซกเมนต์พ่อแม่จะใช้ร่วมกับใบหลายใบ เพื่อกำหนดรูปแบบให้ใช้ระดับที่สอดคล้องกับจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มด้วยจุด `Laptops` ในขณะที่โคน `Software` เริ่มด้วยจุด `Licenses` การเก็บอ้างอิงไปยังจุดเหล่านั้นจะชัดเจนและปลอดภัยกว่าใช้คำสั่งที่ไม่อธิบายเช่น `dataPoints.get_Item(0)` หรือ `dataPoints.get_Item(6)`.

## **สร้างและปรับแต่งแผนภูมิทั้งสองประเภท**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง มันสร้างลำดับชั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก กำหนดรูปแบบป้ายสาขา และบันทึกการนำเสนอ

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // เพิ่มหมวดหมู่ใบ. รายการจัดกลุ่มจะตั้งค่าเมื่อตัวกลุ่มใหม่เริ่มต้น;
        // หมวดหมู่ต่อไปนี้จะอยู่ในกลุ่มนั้นจนกว่าจะมีการตั้งค่ารายการอื่น.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // แสดงหมวดหมู่และค่าบนใบ Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // กำหนดรูปแบบสาขา Consumer ผ่านใบแรกในสาขานั้น.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // กำหนดรูปแบบโคน Software ผ่านใบแรกในโคนนั้น.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout มีผลต่อป้ายพ่อแม่ของ Treemap; Sunburst ใช้วงส่วน.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เซลล์หมวดหมู่และเซลล์ค่าใช้แถว worksheet เดียวกัน ดังนั้นตำแหน่งของคอลเลกชันจึงยังคงจัดแนว เมื่อคุณทำงานกับแผนภูมิที่มีอยู่แทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงที่ตั้งชื่อไว้กับจุดข้อมูลและระดับที่คุณต้องการกำหนดรูปแบบ

## **พฤติกรรมและข้อพิจารณาภาคปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับชั้น วิธีการ [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) ควบคุมวิธีการแสดงป้ายของพ่อแม่ในประเภทแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าและความลึกของวงเพื่อสื่อลำดับชั้น [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) ไม่ควบคุมป้ายของวงของมัน
- แผนภูมิทั้งสองประเภทใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบถึงพ่อแม่เดียวกันที่ส่งกลับโดย [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), ดังนั้นโค้ดการสร้างข้อมูลและการกำหนดรูปแบบระดับสามารถใช้ร่วมกันได้
- ค่าพ่อแม่คำนวณจากใบที่สืบทอด ไม่ควรเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือโคน

### **การเรียงลำดับและลำดับเซกเมนต์**

เครื่องยนต์จัดวางแผนภูมิจะกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและเซกเมนต์วง จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องให้ติดกันก่อนเพิ่มเข้ามา แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นเฉพาะ หากลำดับมีความหมาย ให้ใส่ไว้ในป้ายหรือใช้แผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้กำหนดรูปแบบจะสืบทอดสีจากธีมของงานนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อผลลัพธ์ที่คาดเดาได้ หากต้องการให้แผนภูมิเปลี่ยนตามธีม ให้ใช้สีจากสกีมแทนค่า RGB คงที่และหลีกเลี่ยงการเขียนทับทุกระดับ พร้อมตรวจสอบความคมชัดของป้ายหลังเปลี่ยนสีสาขาหรือโคน

### **ป้ายและพื้นที่ที่มีอยู่**

PowerPoint อาจซ่อนหรือย่อป้ายเมื่อเซกเมนต์เล็กเกินไป การเพิ่มขนาดแผนภูมิ ย่อชื่อหมวดหมู่ หรือแสดงฟิลด์ป้ายน้อยลงมักทำให้ผลลัพธ์ชัดเจนขึ้น ป้ายสามารถรวมชื่อหมวดหมู่ ชื่อชุดข้อมูล และค่าได้ผ่าน [IDataLabelFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatalabelformat/), แต่การเปิดใช้งานทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการเรนเดอร์**

บันทึกเป็น PPTX จะทำให้แผนภูมิแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์งานนำเสนอเป็น PDF หรือภาพ การเติมสีและการตั้งค่าป้ายที่สนับสนุนจะถูกเรนเดอร์พร้อมแผนภูมิ การแทนที่ฟอนต์และความแตกต่างเล็กน้อยของพื้นที่จัดวางที่มีอาจเปลี่ยนการตัดบรรทัดหรือการมองเห็นป้าย ดังนั้นให้ติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับพ่อแม่จึงส่งผลต่อหลายใบ?**  
สาขาหรือโคนเป็นเซกเมนต์ภาพที่ใช้ร่วมกัน สามารถเข้าถึง [IChartDataPointLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapointlevel/) ผ่านใบที่สืบทอดได้ แต่การกำหนดรูปแบบจะเป็นของเซกเมนต์พ่อแม่ที่ใช้ร่วมกัน ไม่ใช่เฉพาะใบนั้นเท่านั้น

**ทำไมจุดข้อมูลบางจุดไม่มีป้าย?**  
ให้เปิดใช้งานฟิลด์ที่ต้องการในออบเจกต์ [IDataLabelFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatalabelformat/) ของป้าย จากนั้นตรวจสอบว่าเซกเมนต์มีพื้นที่เพียงพอ การจัดวางป้ายพ่อแม่ของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดมีผลต่อการแสดงป้ายหรือไม่

**ฉันสามารถกำหนดลำดับหรือพิกัดที่แม่นยำของเซกเมนต์ได้ไหม?**  
คุณสามารถควบคุมลำดับแถวต้นฉบับและให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องยนต์จัดวางแผนภูมิจะคำนวณจากลำดับชั้น ค่าและพื้นที่ที่มีอยู่

**ทำไมสีเปลี่ยนเมื่อธีมของงานนำเสนอเปลี่ยน?**  
การเติมสีแบบอิงธีมถูกออกแบบให้ตามจานสีของงานนำเสนอ ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องคงที่ หรือเก็บสีสกีมไว้เมื่อจำเป็นต้องปรับให้เข้ากับธีมใหม่

**การกำหนดรูปแบบแบบกำหนดเองจะถูกเก็บไว้ในการส่งออกเป็น PDF และภาพหรือไม่?**  
ใช่ การเติมสีแผนภูมิและการตั้งค่าป้ายที่สนับสนุนจะรวมอยู่ในระหว่างการเรนเดอร์ เพื่อผลลัพธ์ที่สม่ำเสมอในหลายระบบ ให้ทำให้ฟอนต์ที่ต้องการพร้อมใช้งานและทดสอบขนาดการส่งออกขั้นสุดท้ายเนื่องจากการปรับป้ายขึ้นอยู่กับการจัดวาง

## **ดูเพิ่มเติม**

- [Create Treemap charts](/slides/th/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/th/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/th/androidjava/export-chart/)
- [Manage presentation themes](/slides/th/androidjava/presentation-theme/)