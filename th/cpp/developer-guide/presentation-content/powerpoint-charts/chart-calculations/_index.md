---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับงานนำเสนอใน C++
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/cpp/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งขององค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบแม่
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides for C++ สำหรับ PPT และ PPTX พร้อมตัวอย่างโค้ด C++ ที่ใช้ได้จริง."
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับการทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าแท้จริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดที่แท้จริงขององค์ประกอบที่เรียกใช้ `IActualLayout` และค่าที่แท้จริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าดังกล่าวจะถูกเติมหลังจากการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้บทความยังสาธิตวิธีการรับตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิแม่และวิธีการซ่อนส่วนประกอบของแผนภูมิ เช่น ชื่อเรื่อง, แกน, ตำนานและเส้นกริด ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการมองเห็นขององค์ประกอบแผนภูมิในไฟล์ PowerPoint ผ่านโปรแกรมได้อย่างมีประสิทธิภาพ

## **คำนวณค่าที่แท้จริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for C++ มี API อย่างง่ายสำหรับการดึงคุณสมบัติเหล่านี้ ซึ่งจะช่วยให้คุณคำนวณค่าที่แท้จริงขององค์ประกอบแผนภูมิ ค่าแท้จริงประกอบด้วยตำแหน่งขององค์ประกอบที่เรียกใช้ IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) และค่าของแกนที่แท้จริง (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// บันทึกงานนำเสนอ
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **คำนวณตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิแม่**
Aspose.Slides for C++ มี API อย่างง่ายสำหรับการดึงคุณสมบัติเหล่านี้ วิธีของ IActualLayout ให้ข้อมูลเกี่ยวกับตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิแม่ จำเป็นต้องเรียกเมธอด IChart::ValidateChartLayout() ก่อนเพื่อให้คุณสมบัติเหล่านี้เต็มด้วยค่าที่แท้จริง

``` cpp
// สร้างงานนำเสนอเปล่า
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **ซ่อนองค์ประกอบแผนภูมิ**
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีการซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for C++ คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิ ตัวอย่างโค้ดด้านล่างแสดงว่าผ่านคุณสมบัติเหล่านี้อย่างไร

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**
Aspose.Slides for C++ มี API ที่ง่ายที่สุดสำหรับการกำหนดช่วงข้อมูลของแผนภูมิในวิธีที่ง่ายที่สุด เพื่อตั้งค่าช่วงข้อมูลของแผนภูมิ:

- เปิดอินสแตนซ์ของคลาส `Presentation` ที่มีแผนภูมิ
- รับอ้างอิงของสไลด์โดยใช้ Index ของสไลด์นั้น
- เดินผ่าน shape ทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ
- เข้าถึงข้อมูลแผนภูมิและตั้งค่าช่วงข้อมูล
- บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีอัปเดตแผนภูมิ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **คำถามที่พบบ่อย**

**แหล่งข้อมูล Excel ภายนอกสามารถใช้เป็นแหล่งข้อมูลได้หรือไม่ และมีผลต่อการคำนวณใหม่อย่างไร?**

ได้. แผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากเวิร์กบุ๊กนั้น และแผนภูมิจะแสดงการอัปเดตในระหว่างการเปิดหรือแก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) path และจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นเทรนด์โดยไม่ต้องเขียนโค้ดการถดถอยเองได้หรือไม่?**

ได้. [Trendlines](/slides/th/cpp/trend-line/) (เชิงเส้น, แบบเอ็กซ์โพเนนเชียล และอื่น ๆ) ถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของเส้นเทรนด์จะคำนวณใหม่จากข้อมูลชุดโดยอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องเขียนการคำนวณของคุณเอง

**หากงานนำเสนอมีแผนภูมิหลายรายการที่มีลิงก์ภายนอก ฉันสามารถควบคุมว่าเวิร์กบุ๊กใดที่แต่ละแผนภูมิใช้สำหรับค่าที่คำนวณได้หรือไม่?**

ได้. แผนภูมิแต่ละรายการสามารถชี้ไปที่ [external workbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) ของตนเองได้ หรือคุณสามารถสร้าง/แทนที่เวิร์กบุ๊กภายนอกต่อแผนภูมิได้อย่างอิสระจากแผนภูมิอื่น ๆ.