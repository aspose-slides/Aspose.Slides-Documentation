---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ใน C++
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ, ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Treemap และ Sunburst chart แสดงข้อมูลเชิงลำดับชั้นประเภทเดียวกัน แต่ใช้การจัดวางที่ต่างกัน Treemap วาดลำดับชั้นเป็นสี่เหลี่ยมซ้อนซึ่งพื้นที่แสดงค่าของใบข้อมูล ส่วน Sunburst วาดเป็นวงแหวนศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์กลาง และหมวดหมู่ใบข้อมูลอยู่บนวงแหวนด้านนอก

ใน Aspose.Slides for C++ แต่ละค่าตัวเลขคือ [IChartDataPoint](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/). เมธอด [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) ให้เข้าถึงใบข้อมูลและกลุ่มพาเรนท์ของมัน บทความนี้อธิบายการแมปนี้และแสดงวิธีสร้างและกำหนดรูปแบบของทั้งสองประเภทแผนภูมิจากข้อมูลตัวอย่างเดียวกัน

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างด้านล่างมีสามระดับของหมวดหมู่และหนึ่งซีรีส์ตัวเลข:

| สาขา | ราก | ใบ | รายรับ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งรายการและจุดข้อมูลหนึ่งรายการ ระดับการจัดกลุ่มหมวดหมู่บรรยายเส้นทางจากใบข้อมูลไปยังพาเรนท์ของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`

ดัชนีที่คืนโดย [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) เริ่มจากใบข้อมูลขึ้นไป:

| ดัชนี `get_DataPointLevels()` | ระดับเชิงตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่า | ส่วนของวงแหวนด้านนอก |
| `1` | ราก | สี่เหลี่ยมพาเรนท์หรือหัวข้อ | ส่วนของวงแหวนกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวข้อ | ส่วนของวงแหวนด้านใน |

ลำดับนี้เหมือนกันสำหรับทั้งสองประเภทแผนภูมิ แม้ว่าการจัดวางภาพจะแตกต่างกัน แต่ส่วนพาเรนท์จะถูกแชร์โดยหลายใบข้อมูล เพื่อกำหนดรูปแบบให้ใช้ระดับที่สอดคล้องกับจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มที่จุด `Laptops` ส่วนราก `Software` เริ่มที่จุด `Licenses` การเก็บอ้างอิงจุดเหล่านี้ทำให้โค้ดชัดเจนและปลอดภัยกว่าใช้การอ้างอิงที่ไม่อธิบายเช่น `dataPoints->idx_get(0)` หรือ `dataPoints->idx_get(6)`

## **สร้างและปรับแต่งทั้งสองประเภทของแผนภูมิ**

ตัวอย่างเต็มด้านล่างสร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง สร้างลำดับชั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก กำหนดรูปแบบป้ายสาขา และบันทึกงานนำเสนอ

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // เพิ่มหมวดหมู่ใบข้อมูล การตั้งค่ารายการจัดกลุ่มจะทำก็ต่อเมื่อกลุ่มใหม่เริ่มต้น;
    // หมวดหมู่ต่อไปนี้จะอยู่ในกลุ่มนั้นจนกว่าจะมีการตั้งค่ารายการใหม่.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // แสดงชื่อหมวดหมู่และค่าในใบข้อมูล Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // กำหนดรูปแบบสาขา Consumer ผ่านใบข้อมูลแรกในสาขานั้น.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // กำหนดรูปแบบราก Software ผ่านใบข้อมูลแรกในรากนั้น.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout มีผลต่อป้ายพาเรนท์ของ Treemap; Sunburst ใช้ส่วนของวงแหวน.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เซลล์หมวดหมู่และเซลล์ค่าตัวเลขใช้แถวงานชีตเดียวกัน ดังนั้นตำแหน่งของคอลเลกชันจึงยังคงสอดคล้องกัน เมื่อคุณทำงานกับแผนภูมิที่มีอยู่แล้วแทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและจัดเก็บอ้างอิงที่ตั้งชื่อของจุดข้อมูลและระดับที่คุณต้องการกำหนดรูปแบบ

## **พฤติกรรมและข้อพิจารณาทางปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าและสี่เหลี่ยมซ้อนเพื่อสื่อลำดับชั้น เมธอด [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) ควบคุมวิธีการแสดงป้ายพาเรนท์ในประเภทแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าและความลึกของวงแหวนเพื่อสื่อลำดับชั้น [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) ไม่ควบคุมป้ายวงแหวนของมัน
- ทั้งสองประเภทแผนภูมิใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบถึงพาเรนท์เดียวกันที่คืนโดย [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), ดังนั้นโค้ดการสร้างข้อมูลและการกำหนดรูปแบบระดับสามารถใช้ร่วมกันได้
- ค่าพาเรนท์คำนวณจากใบข้อมูลที่สืบทอด อย่าสร้างจุดตัวเลขแยกสำหรับสาขาหรือราก

### **การจัดเรียงและลำดับส่วน**

เครื่องยนต์จัดวางแผนภูมิกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนของวงแหวน จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องให้อยู่ด้วยกันก่อนเพิ่มเข้าไป แต่ไม่ควรอาศัยตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นที่เฉพาะเจาะจง หากลำดับมีความหมาย ให้รวมไว้ในป้ายหรือใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ยังไม่ได้กำหนดรูปแบบจะสืบทอดสีจากธีมงานนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อผลลัพธ์ที่คาดการณ์ได้ หากต้องการให้แผนภูมิติดตามการเปลี่ยนแปลงธีม ให้ใช้สีสกีมแทนค่า RGB คงที่และหลีกเลี่ยงการเขียนทับทุกระดับ นอกจากนี้ควรตรวจสอบความคมชัดของป้ายหลังเปลี่ยนสีสกีมของสาขาหรือราก

### **ป้ายและพื้นที่ที่ใช้ได้**

PowerPoint อาจซ่อนหรือตัดป้ายเมื่อส่วนมีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ ลดความยาวชื่อหมวดหมู่ หรือแสดงจำนวนฟิลด์ป้ายน้อยลงมักทำให้ผลลัพธ์ชัดเจนขึ้น ป้ายสามารถรวมชื่อหมวดหมู่, ชื่อซีรีส์, และค่าได้ผ่าน [IDataLabelFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatalabelformat/), แต่การเปิดใช้ทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการเรนเดอร์**

การบันทึกเป็น PPTX จะทำให้แผนภูมิสารถแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์งานนำเสนอเป็น PDF หรือภาพ การเติมสีและการตั้งค่าป้ายที่รองรับจะถูกเรนเดอร์พร้อมแผนภูมิ การแทนที่ฟอนต์และความแตกต่างเล็กน้อยของพื้นที่จัดวางที่มีอยู่สามารถทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนแปลงได้ ดังนั้นควรติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับพาเรนท์จึงส่งผลต่อหลายใบข้อมูล?**

สาขาหรือรากเป็นส่วนภาพที่แชร์กันได้ [IChartDataPointLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/) สามารถเข้าถึงได้ผ่านใบข้อมูลที่สืบทอด แต่การกำหนดรูปแบบเป็นของส่วนพาเรนท์ที่แชร์ ไม่ได้เป็นของใบข้อมูลเท่านั้น

**ทำไมป้ายข้อมูลจึงหายไป?**

ก่อนอื่นเปิดฟิลด์ที่ต้องการบนวัตถุ [IDataLabelFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatalabelformat/) ของป้าย แล้วตรวจสอบว่าบริเวณของส่วนมีที่ว่างพอหรือไม่ การจัดวางป้ายพาเรนท์ของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์, และจำนวนฟิลด์ที่เปิดใช้ทั้งหมดส่งผลต่อการแสดงหรือไม่ของป้าย

**ฉันสามารถกำหนดลำดับหรือพิกัดที่แน่นอนของส่วนได้หรือไม่?**

คุณสามารถควบคุมลำดับแถวต้นทางและทำให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องยนต์จัดวางแผนภูมิคำนวณจากลำดับชั้น, ค่า, และพื้นที่ที่ใช้ได้

**ทำไมสีถึงเปลี่ยนหลังจากธีมงานนำเสนอเปลี่ยน?**

การเติมสีตามธีมออกแบบให้สอดคล้องกับพาเล็ตของงานนำเสนอ ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องคงที่ หรือใช้สีสกีมเมื่อการปรับให้เข้ากับธีมใหม่เป็นสิ่งที่ต้องการ

**การกำหนดรูปแบบแบบกำหนดเองจะถูกรักษาไว้ในไฟล์ PDF และภาพหรือไม่?**

ใช่ สีเติมของแผนภูมิและการตั้งค่าป้ายที่รองรับจะถูกรวมเข้ากับการเรนเดอร์ เพื่อผลลัพธ์ที่สม่ำเสมอข้ามระบบ ให้เตรียมฟอนต์ที่จำเป็นและทดสอบขนาดการส่งออกขั้นสุดท้าย เนื่องจากการจับป้ายขึ้นอยู่กับการจัดวาง

## **ดูเพิ่มเติม**

- [Create Treemap charts](/slides/th/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/th/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/th/cpp/export-chart/)
- [Manage presentation themes](/slides/th/cpp/presentation-theme/)