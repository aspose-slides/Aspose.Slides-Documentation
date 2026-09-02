---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย JavaScript
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ ป้าย และสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Treemap และ Sunburst chart แสดงข้อมูลเชิงลำดับชั้นในรูปแบบเดียวกัน แต่ใช้รูปแบบการจัดวางที่แตกต่างกัน Treemap วาดลำดับชั้นเป็นสี่เหลี่ยมซ้อนกัน ซึ่งพื้นที่ของสี่เหลี่ยมแทนค่าที่เป็นใบไม้ Sunburst วาดเป็นวงจรศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์กลาง และหมวดหมู่ใบอยู่บนวงแหวนด้านนอก

ใน Aspose.Slides for Node.js via Java ค่าตัวเลขแต่ละค่าจะเป็น [ChartDataPoint](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/) วิธี [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) ให้เข้าถึงใบไม้และกลุ่มพาเรนท์ของมัน บทความนี้อธิบายการแมปนี้และแสดงวิธีสร้างและจัดรูปแบบทั้งสองประเภทของแผนภูมิจากชุดข้อมูลตัวอย่างเดียวกัน

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **ทำความเข้าใจประเภท, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีระดับหมวดหมู่สามระดับและชุดตัวเลขหนึ่งชุด:

| สาขา | ส่วน | ใบไม้ | รายได้ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละแถวสร้างหมวดหมู่ใบไม้หนึ่งรายการและจุดข้อมูลหนึ่งรายการ ระดับการจัดกลุ่มหมวดหมู่บรรยายเส้นทางจากใบไม้นั้นไปยังพาเรนท์ของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`

ดัชนีที่คืนค่าจาก [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) เริ่มจากใบไม้ขึ้นไปบนพาเรนท์:

| `getDataPointLevels()` index | ระดับตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบไม้ | สี่เหลี่ยมค่าตัว | ส่วนของวงแหวนนอก |
| `1` | ส่วน | สี่เหลี่ยมพาเรนท์หรือหัวข้อ | ส่วนของวงแหวนกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวข้อ | ส่วนของวงแหวนใน |

ลำดับนี้เหมือนกันสำหรับทั้งสองประเภทของแผนภูมิ แม้ว่าการจัดวางภาพจะแตกต่างกัน กรากพาเรนท์ถูกใช้ร่วมโดยหลายใบไม้ เพื่อจัดรูปแบบให้ใช้ระดับของจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มต้นด้วยจุด `Laptops` ในขณะที่ส่วน `Software` เริ่มต้นด้วยจุด `Licenses` การเก็บอ้างอิงไปยังจุดเหล่านั้นทำให้โค้ดชัดเจนและปลอดภัยกว่าการใช้การอ้างอิงที่ไม่อธิบายเช่น `dataPoints.get_Item(0)` หรือ `dataPoints.get_Item(6)`

## **สร้างและปรับแต่งแผนภูมิทั้งสองประเภท**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง สร้างลำดับชั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก จัดรูปแบบป้ายสาขา และบันทึกการนำเสนอ

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // เพิ่มหมวดหมู่ใบไม้ การตั้งค่ารายการจัดกลุ่มจะทำเฉพาะเมื่อเริ่มกลุ่มใหม่;
        // หมวดหมู่ต่อไปนี้จะคงอยู่ในกลุ่มนั้นจนกว่าจะตั้งค่ารายการอื่น.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // แสดงหมวดหมู่และค่าในใบไม้ Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // จัดรูปแบบสาขา Consumer ผ่านใบไม้แรกในสาขานั้น.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // จัดรูปแบบสเต็ม Software ผ่านใบไม้แรกในสเต็มนั้น.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout มีผลต่อป้ายพาเรนท์ของ Treemap; Sunburst ใช้ส่วนของวงแหวน.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เซลล์หมวดหมู่และเซลล์ค่าผลใช้แถว worksheet เดียวกัน ดังนั้นตำแหน่งในคอลเลกชันจะยังคงสอดคล้องกัน เมื่อทำงานกับแผนภูมิที่มีอยู่แล้วแทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและจัดเก็บการอ้างอิงที่ตั้งชื่อไปยังจุดข้อมูลและระดับที่ตั้งใจจะจัดรูปแบบ

## **พฤติกรรมและข้อพิจารณาเชิงปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าตัวเลขและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับชั้น วิธี [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) ควบคุมการแสดงป้ายพาเรนท์ในประเภทแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าตัวเลขและความลึกของวงแหวนเพื่อสื่อลำดับชั้น วิธี [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) ไม่ควบคุมป้ายวงแหวนของมัน
- ทั้งสองประเภทใช้ระดับการจัดกลุ่มหมวดหมู่และลำดับใบไม้‑ไป‑พาเรนท์เดียวกันที่คืนค่าจาก [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) ดังนั้นโค้ดการสร้างข้อมูลและการจัดรูปแบบระดับจึงสามารถใช้ร่วมกันได้
- ค่าพาเรนท์คำนวณจากใบไม้ที่สืบทอด ไม่ต้องเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือส่วน

### **การจัดเรียงและลำดับส่วน**

กลไกการจัดวางแผนภูมิจะกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนของวงแหวน จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องไว้ด้วยกันก่อนเพิ่มเข้าไป แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นเฉพาะ หากลำดับมีความหมาย ควรรวมไว้ในป้ายหรือต้องใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้จัดรูปแบบจะสืบทอดสีจากธีมของการนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อผลลัพธ์ที่คาดเดาได้ หากต้องการให้แผนภูมิตามการเปลี่ยนแปลงธีม ควรใช้สีจากสคีมแทนค่ารหัส RGB คงที่ และหลีกเลี่ยงการเขียนทับทุกระดับ ตรวจสอบความแตกต่างของป้ายหลังจากเปลี่ยนการเติมสีของสาขาหรือส่วน

### **ป้ายและพื้นที่ที่ใช้ได้**

PowerPoint อาจซ่อนหรือย่อป้ายเมื่อส่วนมีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ ย่อชื่อหมวดหมู่ หรือแสดงฟิลด์ป้ายน้อยลงมักให้ผลลัพธ์ที่ชัดเจน ป้ายสามารถรวมชื่อหมวดหมู่ ชื่อชุดข้อมูล และค่าได้ผ่าน [DataLabelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat/) แต่การเปิดใช้งานทุกฟิลด์อาจทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการแสดงผล**

การบันทึกเป็น PPTX ทำให้แผนภูมิสามารถแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์การนำเสนอเป็น PDF หรือรูปภาพ การเติมสีและการตั้งค่าป้ายที่สนับสนุนจะถูกเรนเดอร์พร้อมแผนภูมิ การเปลี่ยนฟอนต์และความแตกต่างเล็กน้อยของพื้นที่จัดวางอาจทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนแปลง ดังนั้นควรติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับพาเรนท์ถึงส่งผลต่อหลายใบไม้?**

สาขาหรือส่วนเป็นส่วนภาพที่ใช้ร่วมกัน พาเรนท์ของมัน ([ChartDataPointLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapointlevel/)) สามารถเข้าถึงได้ผ่านใบไม้ที่สืบทอด แต่การจัดรูปแบบเป็นของส่วนพาเรนท์ที่ใช้ร่วม ไม่ได้เป็นของใบไม้เท่านั้น

**ทำไมป้ายข้อมูลจึงหายไป?**

อันดับแรกให้เปิดฟิลด์ที่ต้องการบนออบเจ็กต์ [DataLabelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat/) ของป้าย แล้วตรวจสอบว่ามีพื้นที่เพียงพอหรือไม่ การจัดวางป้ายพาเรนท์ของ Treemap, มิติของแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์, และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดมีผลต่อการแสดงป้าย

**ฉันสามารถกำหนดลำดับหรือพิกัดของส่วนได้อย่างแม่นยำหรือไม่?**

คุณสามารถควบคุมลำดับแถวแหล่งและให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ กลไกการจัดวางแผนภูมิคำนวณจากลำดับชั้น ค่าและพื้นที่ที่ใช้ได้

**ทำไมสีถึงเปลี่ยนหลังจากธีมของการนำเสนอเปลี่ยน?**

การเติมสีที่อิงธีมออกแบบมาให้ตามพาเลตของการนำเสนอ ให้ใช้สี RGB ชัดเจนกับระดับที่ต้องคงที่ หรือเก็บสีสคีมไว้เมื่อการปรับให้เข้ากับธีมใหม่เป็นที่ต้องการ

**การจัดรูปแบบแบบกำหนดเองจะคงอยู่ในการส่งออกเป็น PDF และรูปภาพหรือไม่?**

ใช่ การเติมสีแผนภูมิและการตั้งค่าป้ายที่สนับสนุนจะถูกรวมไว้ระหว่างการเรนเดอร์ เพื่อผลลัพธ์ที่สม่ำเสมอระหว่างระบบต่างๆ ให้ทำให้ฟอนต์ที่จำเป็นพร้อมใช้งานและทดสอบขนาดการส่งออกสุดท้าย เนื่องจากการจัดวางป้ายขึ้นกับพื้นที่

## **ดูเพิ่มเติม**

- [Create Treemap charts](/slides/th/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/th/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/th/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/th/nodejs-java/presentation-theme/)