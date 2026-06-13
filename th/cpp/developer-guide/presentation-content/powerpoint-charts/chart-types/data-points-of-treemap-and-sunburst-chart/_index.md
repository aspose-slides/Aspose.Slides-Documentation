---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย С++
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- การนำเสนอ
- С++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ С++ ที่รองรับรูปแบบของ PowerPoint."
---
## **บทนำ**

นอกเหนือจากประเภทอื่นของแผนภูมิ PowerPoint มีสองประเภท “แบบลำดับชั้น” คือแผนภูมิ **Treemap** และ **Sunburst** (ที่รู้จักกันในชื่อ Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลเชิงลำดับชั้นที่จัดระเบียบเป็นต้นไม้ – จากใบต่อถึงยอดของกิ่ง ใบถูกกำหนดโดยจุดข้อมูลของซีรีส์ และแต่ละระดับการจัดกลุ่มซ้อนไปต่อโดยกำหนดโดยหมวดหมู่ที่สอดคล้อง Aspose.Slides for C++ ช่วยให้สามารถจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ใน C++ ได้

นี่คือแผนภูมิ Sunburst ที่ข้อมูลในคอลัมน์ Series1 กำหนดโหนดใบ ในขณะที่คอลัมน์อื่นกำหนดจุดข้อมูลเชิงลำดับชั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ลงในงานพรีเซนเทชั่น:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [**สร้างแผนภูมิ Sunburst**](/slides/th/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/) classes and [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method provide access to format data points of Treemap and Sunburst charts.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) is used for accessing multi-level categories - it represents the container of [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/) objects. 
Basically it is a wrapper for [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) with the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/) class has two methods: [**get_Format()**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) and [**get_Label()**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) which provide access to corresponding settings.

## **แสดงค่าจุดข้อมูล**
แสดงค่าของจุดข้อมูล "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **ตั้งค่าป้ายและสีของจุดข้อมูล**
ตั้งค่าป้ายข้อมูลของ "Branch 1" ให้แสดงชื่อซีรีส์ ("Series1") แทนชื่อหมวดหมู่ จากนั้นตั้งค่าสีข้อความเป็นสีเหลือง:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **ตั้งค่าสีสาขาของจุดข้อมูล**
เปลี่ยนสีของสาขา "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนลำดับ (การจัดเรียง) ของเซกเมนต์ใน Sunburst/Treemap ได้หรือไม่?**

ไม่ PowerPoint จะจัดเรียงเซกเมนต์โดยอัตโนมัติ (โดยทั่วไปตามค่าลดลงตามเข็มนาฬิกา) Aspose.Slides ทำตามพฤติกรรมนี้: คุณไม่สามารถเปลี่ยนลำดับได้โดยตรง; คุณต้องทำโดยการประมวลผลข้อมูลล่วงหน้า

**ธีมของงานพรีเซนเทชั่นมีผลต่อสีของเซกเมนต์และป้ายอย่างไร?**

สีของแผนภูมิจะสืบทอดจาก [theme/palette](/slides/th/cpp/presentation-theme/) ของงานพรีเซนเทชั่น เว้นแต่คุณจะกำหนดการเติมสี/ฟอนต์อย่างเจาะจง เพื่อผลลัพธ์ที่สม่ำเสมอ ควรล็อกการเติมสีแบบทึบและการจัดรูปแบบข้อความในระดับที่ต้องการ

**การส่งออกเป็น PDF/PNG จะรักษาสีสาขาที่กำหนดเองและการตั้งค่าป้ายไว้หรือไม่?**

ใช่ เมื่อส่งออกงานพรีเซนเทชั่น การตั้งค่าแผนภูมิ (การเติมสี, ป้าย) จะถูกเก็บไว้ในรูปแบบผลลัพธ์ เนื่องจาก Aspose.Slides จะเรนเดอร์ด้วยการจัดรูปแบบของแผนภูมิที่ได้กำหนดไว้

**ฉันสามารถคำนวณพิกัดจริงของป้าย/อิลิเมนต์สำหรับการวาง overlay แบบกำหนดเองบนแผนภูมิได้หรือไม่?**

ใช่ หลังจากที่การจัดวางแผนภูมิได้รับการตรวจสอบแล้ว ค่า X และ Y จริงจะพร้อมใช้งานสำหรับอิลิเมนต์ (เช่น [DataLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/datalabel/)) ซึ่งช่วยให้วาง overlay อย่างแม่นยำ