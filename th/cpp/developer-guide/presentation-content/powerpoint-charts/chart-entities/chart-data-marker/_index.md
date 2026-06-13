---
title: จัดการตัวบ่งชี้ข้อมูลแผนภูมิในงานนำเสนอด้วย С++
linktitle: ตัวบ่งชี้ข้อมูล
type: docs
url: /th/cpp/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวบ่งชี้
- ตัวเลือกตัวบ่งชี้
- ขนาดตัวบ่งชี้
- ประเภทการเติม
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides สำหรับ С++ เพื่อเพิ่มประสิทธิภาพของงานนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ด С++ ที่ชัดเจน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีสร้างแผนภูมิ, เข้าถึงชุดข้อมูลและจุดข้อมูลของมัน, ใช้การเติมภาพให้กับตัวบ่งชี้ในระดับจุดข้อมูล, ปรับขนาดตัวบ่งชี้, และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังระบุว่ารูปทรงตัวบ่งชี้มาตรฐานสามารถใช้ผ่าน enumeration `MarkerStyleType` และว่าลักษณะของตัวบ่งชี้จะถูกรักษาหากส่งออกแผนภูมิเป็นรูปแบบ raster หรือ SVG.

## **ตั้งค่าตัวบ่งชี้แผนภูมิ**
Aspose.Slides for C++ มี API ที่ง่ายสำหรับตั้งค่าตัวบ่งชี้ของชุดข้อมูลแผนภูมิโดยอัตโนมัติ ในฟีเจอร์ต่อไปนี้ ชุดข้อมูลแผนภูมิแต่ละชุดจะได้รับสัญลักษณ์ตัวบ่งชี้เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตัวบ่งชี้ของชุดข้อมูลแผนภูมิโดยอัตโนมัติ

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **ตั้งค่าตัวเลือกตัวบ่งชี้แผนภูมิ**
สามารถตั้งค่าตัวบ่งชี้บนจุดข้อมูลของแผนภูมิในชุดข้อมูลเฉพาะได้ เพื่อกำหนดตัวเลือกของตัวบ่งชี้แผนภูมิ กรุณาตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- ดึงชุดข้อมูลแผนภูมิชุดแรก
- เพิ่มจุดข้อมูลใหม่
- บันทึกงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตัวเลือกตัวบ่งชี้แผนภูมิบนระดับจุดข้อมูล

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **ตั้งค่าตัวบ่งชี้แผนภูมิในระดับจุดข้อมูลของชุดข้อมูล**
ขณะนี้ สามารถตั้งค่าตัวบ่งชี้บนจุดข้อมูลของแผนภูมิในชุดข้อมูลเฉพาะได้ เพื่อกำหนดตัวเลือกของตัวบ่งชี้แผนภูมิ กรุณาตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- ดึงชุดข้อมูลแผนภูมิชุดแรก
- เพิ่มจุดข้อมูลใหม่
- บันทึกงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตัวบ่งชี้แผนภูมิบนระดับจุดข้อมูล

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **ใช้สีกับจุดข้อมูล**
คุณสามารถใช้สีกับจุดข้อมูลในแผนภูมิด้วย Aspose.Slides for C++ ได้ มีการเพิ่มคลาส[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) และ**[IChartDataPointLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/)** เพื่อเข้าถึงคุณสมบัติของระดับจุดข้อมูล บทความนี้แสดงวิธีเข้าถึงและใช้สีกับจุดข้อมูลในแผนภูมิ

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **คำถามที่พบบ่อย**

**รูปทรงตัวบ่งชี้ที่มีให้ใช้งานโดยตรงมีอะไรบ้าง?**

มีรูปทรงมาตรฐานให้เลือกใช้ (วงกลม, สี่เหลี่ยมจัตุรัส, เพชร, สามเหลี่ยม ฯลฯ); รายการนี้กำหนดโดย enumeration[MarkerStyleType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/markerstyletype/) หากต้องการรูปทรงที่ไม่เป็นมาตรฐาน ให้ใช้ตัวบ่งชี้ที่เติมภาพเพื่อจำลองภาพกราฟิกที่กำหนดเอง

**ตัวบ่งชี้จะถูกรักษาไว้เมื่อนำแผนภูมิออกเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเราดึงแผนภูมิเป็น[raster formats](/slides/th/cpp/convert-powerpoint-to-png/) หรือบันทึก[shapes as SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/) ตัวบ่งชี้จะคงลักษณะและการตั้งค่าของมันไว้ รวมถึงขนาด, การเติมสี, และเส้นขอบ