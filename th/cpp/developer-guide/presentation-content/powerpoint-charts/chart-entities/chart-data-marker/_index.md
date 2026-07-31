---
title: "จัดการตัวบ่งชี้ข้อมูลแผนภูมิในงานนำเสนอด้วย C++"
linktitle: "ตัวบ่งชี้ข้อมูล"
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
- C++
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides for C++ เพื่อเพิ่มประสิทธิภาพงานนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ด C++ ที่ชัดเจน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีการสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ประยุกต์การเติมรูปภาพให้กับตัวบ่งชี้ในระดับจุดข้อมูล, ปรับขนาดตัวบ่งชี้, และบันทึกงานนำเสนอที่อัปเดตแล้ว นอกจากนี้ยังระบุว่ารูปแบบตัวบ่งชี้มาตรฐานสามารถใช้ได้ผ่าน enumeration `MarkerStyleType` และรูปลักษณ์ของตัวบ่งชี้จะถูกเก็บไว้เมื่อส่งออกแผนภูมิเป็นรูปแบบเรสเตอร์หรือ SVG

## **ตั้งค่าตัวบ่งชี้แผนภูมิ**
Aspose.Slides for C++ มี API ที่ง่ายในการตั้งค่าตัวบ่งชี้ซีรีส์ของแผนภูมิโดยอัตโนมัติ ในคุณลักษณะต่อไปนี้แต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์ตัวบ่งชี้เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ดตัวอย่างด้านล่างแสดงวิธีการตั้งค่าตัวบ่งชี้ซีรีส์ของแผนภูมิโดยอัตโนมัติ

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **ตั้งค่าตัวเลือกตัวบ่งชี้แผนภูมิ**
สามารถตั้งค่าตัวบ่งชี้บนจุดข้อมูลของแผนภูมิภายในซีรีส์ที่กำหนดได้ เพื่อกำหนดตัวเลือกตัวบ่งชี้แผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)คลาส
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- เลือกซีรีส์แรกของแผนภูมิ
- เพิ่มจุดข้อมูลใหม่
- เขียนงานนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตัวเลือกตัวบ่งชี้แผนภูมิในระดับจุดข้อมูล

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **ตั้งค่าตัวบ่งชี้แผนภูมิบนระดับจุดข้อมูลของซีรีส์**
ตอนนี้สามารถตั้งค่าตัวบ่งชี้บนจุดข้อมูลของแผนภูมิภายในซีรีส์ที่กำหนดได้ เพื่อกำหนดตัวเลือกตัวบ่งชี้แผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์Presentationคลาส
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- เลือกซีรีส์แรกของแผนภูมิ
- เพิ่มจุดข้อมูลใหม่
- เขียนงานนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตัวเลือกตัวบ่งชี้แผนภูมิในระดับจุดข้อมูล

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Access first slide
// Add chart with default data
// Setting the index of chart data sheet
// Getting the chart data worksheet
// Delete default generated series and categories
// Now, Adding a new series
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

## **ประยุกต์ใช้สีกับจุดข้อมูล**
คุณสามารถประยุกต์ใช้สีกับจุดข้อมูลในแผนภูมิด้วย Aspose.Slides for C++ โดยมีคลาส[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)และ[**IChartDataPointLevel**](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointlevel/)ที่เพิ่มเข้ามาเพื่อเข้าถึงคุณสมบัติของระดับจุดข้อมูล บทความนี้จะแสดงวิธีการเข้าถึงและประยุกต์ใช้สีกับจุดข้อมูลในแผนภูมิ

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **คำถามที่พบบ่อย**

**รูปแบบตัวบ่งชี้ที่พร้อมใช้มีอะไรบ้าง?**

มีรูปแบบมาตรฐาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการกำหนดโดย enumeration[MarkerStyleType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/markerstyletype/) หากต้องการรูปแบบที่ไม่มาตรฐาน ให้ใช้ตัวบ่งชี้พร้อมเติมรูปภาพเพื่อจำลองภาพแบบกำหนดเอง

**ตัวบ่งชี้จะถูกเก็บไว้เมื่อส่งออกแผนภูมิเป็นรูปภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเรนเดอร์แผนภูมิเป็น[รูปแบบเรสเตอร์](/slides/th/cpp/convert-powerpoint-to-png/)หรือบันทึก[รูปร่างเป็น SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/) ตัวบ่งชี้จะคงรูปลักษณ์และการตั้งค่าต่าง ๆ รวมถึงขนาด, การเติม, และโครงร่างไว้ครบถ้วน