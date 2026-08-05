---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย Java
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ Treemap
- แผนภูมิ Sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

แผนภูมิ Treemap และ Sunburst แสดงข้อมูลเชิงลำดับชั้นแบบเดียวกัน แต่ใช้การจัดวางที่ต่างกัน Treemap วาดลำดับชั้นเป็นสี่เหลี่ยมซ้อนกันโดยพื้นที่แทนค่าของใบ (leaf) ส่วน Sunburst วาดเป็นวงแหวนศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์กลางและหมวดหมู่ใบอยู่บนวงแหวนภายนอก

ใน Aspose.Slides for Java ค่าตัวเลขแต่ละค่าจะเป็น [IChartDataPoint](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/) เมธอด [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) ให้เข้าถึงใบและกลุ่มผู้ปกครองของมัน บทความนี้อธิบายการแม็พนี้และแสดงวิธีสร้างและกำหนดรูปแบบของทั้งสองประเภทแผนภูมิจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap กับสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst กับโครงสร้าง Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีระดับหมวดหมู่สามระดับและชุดข้อมูลเชิงตัวเลขหนึ่งชุด:

| สาขา | ส่วนย่อย | ใบ | รายได้ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งรายการและจุดข้อมูลหนึ่งรายการ ระดับการจัดกลุ่มของหมวดหมู่บรรยายเส้นทางจากใบนั้นไปถึงผู้ปกครองของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`.

ดัชนีที่คืนค่าจาก [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) จะไล่จากใบขึ้นไปบนสุด:

| `getDataPointLevels()` ดัชนี | ระดับเชิงตรรกะ | การแทนค่าใน Treemap | การแทนค่าใน Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่าตัวเลข | ส่วนของวงแหวนภายนอก |
| `1` | ส่วนย่อย | สี่เหลี่ยมหรือส่วนหัวผู้ปกครอง | ส่วนของวงแหวนระดับกลาง |
| `2` | สาขา | สี่เหลี่ยมหรือส่วนหัวระดับบน | ส่วนของวงแหวนภายใน |

ลำดับนี้เหมือนกันสำหรับแผนภูมิทั้งสอง แม้ว่าการจัดวางภาพจะแตกต่างกัน กรองส่วนผู้ปกครองจะแชร์โดยหลายใบ เพื่อกำหนดรูปแบบให้ใช้ระดับของจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มจากจุด `Laptops` ขณะที่ส่วน `Software` เริ่มจากจุด `Licenses` การเก็บอ้างอิงไปยังจุดเหล่านั้นทำให้โค้ดชัดเจนและปลอดภัยกว่าการใช้การอ้างอิงที่ไม่อธิบายเช่น `dataPoints.get_Item(0)` หรือ `dataPoints.get_Item(6)`.

## **สร้างและปรับแต่งแผนภูมิทั้งสองประเภท**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง มันสร้างโครงสร้าง, แสดงค่าของ `Tablets`, ใช้สีคงที่กับระดับที่เลือก, กำหนดรูปแบบป้ายสาขา, และบันทึกงานพรีเซนเทชัน

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

        // เพิ่มหมวดหมู่ระดับใบ. รายการจัดกลุ่มจะถูกตั้งค่าเฉพาะเมื่อเริ่มกลุ่มใหม่;
        // หมวดหมู่ต่อไปนี้จะคงอยู่ในกลุ่มนั้นจนกว่ารายการอื่นจะถูกตั้งค่า.
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

        // แสดงหมวดหมู่และค่าในใบ Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // กำหนดรูปแบบสาขา Consumer ผ่านใบแรกในสาขานั้น.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // กำหนดรูปแบบส่วนย่อย Software ผ่านใบแรกในส่วนย่อยนั้น.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ส่งผลต่อป้ายผู้ปกครองของ Treemap; Sunburst ใช้ส่วนของวงแหวน.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เซลล์หมวดหมู่และเซลล์ค่าจะใช้แถว Worksheet เดียวกัน ดังนั้นตำแหน่งของคอลเลกชันจึงยังคงสอดคล้องกัน เมื่อคุณทำงานกับแผนภูมิที่มีอยู่แทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงที่ตั้งชื่อไว้สำหรับจุดข้อมูลและระดับที่คุณตั้งใจจะกำหนดรูปแบบ

## **พฤติกรรมและข้อควรพิจารณาเชิงปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่ในการสื่อค่าตัวเลขและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับชั้น เมธอด [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) ควบคุมว่าป้ายผู้ปกครองจะแสดงอย่างไรในประเภทแผนภูมินี้
- Sunburst ใช้มุมในการสื่อค่าตัวเลขและความลึกของวงเพื่อสื่อลำดับชั้น เมธอดเดียวกันไม่ควบคุมป้ายของวงแหวน
- แผนภูมิทั้งสองใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบ‑ถึง‑ผู้ปกครองเดียวกันที่คืนค่าจาก [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) ดังนั้นโค้ดการสร้างข้อมูลและการฟอร์แมตระดับสามารถใช้ร่วมกันได้
- ค่าผู้ปกครองคำนวณจากใบลูกหลานของมัน ไม่ควรเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือส่วนย่อย

### **การจัดเรียงและลำดับส่วน**

เอนจินการจัดวางแผนภูมิจะกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนของวงแหวน จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องให้อยู่ด้วยกันก่อนเพิ่มลงในแผนภูมิ แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นที่เจาะจง หากลำดับมีความหมาย ให้รวมไว้ในป้ายหรือใช้แผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้กำหนดรูปแบบจะสืบสีจากธีมของพรีเซนเทชัน ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อให้ผลลัพธ์คาดเดาได้ หากต้องการให้แผนภูมิเปลี่ยนตามธีม ควรใช้สีจากสคีมแทนค่าตายตัวและหลีกเลี่ยงการเขียนทับทุกระดับ อีกทั้งควรตรวจสอบคอนทราสต์ของป้ายหลังเปลี่ยนสีสาขาหรือส่วนย่อย

### **ป้ายและพื้นที่ที่มีอยู่**

PowerPoint อาจซ่อนหรือตัดทอนป้ายเมื่อส่วนมีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ, ย่อตัวอักษรชื่อหมวดหมู่, หรือแสดงฟิลด์ป้ายน้อยลงมักจะให้ผลลัพธ์ที่ชัดเจน ป้ายสามารถรวมชื่อหมวดหมู่, ชื่อชุดข้อมูล, และค่าได้ผ่าน [IDataLabelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat/) แต่การเปิดทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการเรนเดอร์**

การบันทึกเป็น PPTX ทำให้แผนภูมิยังแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์พรีเซนเทชันเป็น PDF หรือรูปภาพ การเติมสีและการตั้งค่าป้ายที่สนับสนุนจะถูกรวมด้วย การแทนที่ฟอนต์และความแตกต่างเล็กน้อยของพื้นที่จัดวางที่ใช้ได้อาจทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนแปลง ดังนั้นควรติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับผู้ปกครองจึงส่งผลต่อหลายใบ?**

สาขาหรือส่วนย่อยเป็นส่วนที่แชร์กันหลายใบ สามารถเข้าถึง [IChartDataPointLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointlevel/) ผ่านใบลูกหลานได้ แต่การฟอร์แมตจะเป็นของส่วนผู้ปกครองที่แชร์ ไม่ได้เป็นของใบเดียวเท่านั้น

**ทำไมจุดข้อมูลบางจุดถึงไม่มีป้าย?**

แรกสุดให้เปิดใช้งานฟิลด์ที่ต้องการในวัตถุ [IDataLabelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat/) ของป้าย แล้วตรวจสอบว่ามีพื้นที่เพียงพอหรือไม่ การจัดวางป้ายผู้ปกครองใน Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์, และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดต่างมีผลต่อการแสดงป้าย

**ฉันสามารถกำหนดลำดับหรือพิกัดของส่วนได้อย่างแม่นยำหรือไม่?**

คุณสามารถควบคุมลำดับของแถวแหล่งข้อมูลและทำให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เอนจินจัดวางแผนภูมิคำนวณจากโครงสร้าง, ค่า, และพื้นที่ที่มี

**ทำไมสีถึงเปลี่ยนเมื่อธีมพรีเซนเทชันเปลี่ยน?**

การเติมสีตามธีมออกแบบมาให้สอดคล้องกับพาเล็ตของพรีเซนเทชัน ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องคงที่ หรือใช้สีจากสคีมเมื่อยอมรับการเปลี่ยนธีม

**การฟอร์แมตแบบกำหนดเองจะคงไว้ในไฟล์ PDF และภาพหรือไม่?**

ใช่ การเติมสีและการตั้งค่าป้ายที่สนับสนุนจะถูกรวมในการเรนเดอร์ เพื่อผลลัพธ์สม่ำเสมอระหว่างระบบ ให้ทำให้ฟอนต์ที่ต้องการพร้อมและทดสอบขนาดการส่งออกสุดท้ายเนื่องจากการจัดวางป้ายขึ้นกับพื้นที่

## **ดูเพิ่มเติม**

- [Create Treemap charts](/slides/th/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/th/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/th/java/export-chart/)
- [Manage presentation themes](/slides/th/java/presentation-theme/)