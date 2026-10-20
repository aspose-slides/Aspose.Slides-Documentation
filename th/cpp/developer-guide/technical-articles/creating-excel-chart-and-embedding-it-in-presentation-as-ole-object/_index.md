---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 40
url: /th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells for C++ และฝังสมุดงานในงานนำเสนอ PowerPoint ด้วย Aspose.Slides รวมถึงภาพพรีวิวแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิคอลัมน์ของ Excel ด้วย Aspose.Cells for C++ และฝังสมุดงานของมันลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for C++ สมุดงานที่ฝังไว้จะประกอบด้วยข้อมูลต้นฉบับและแผนภูมิ พร้อมภาพพรีวิว PNG แยกต่างหากที่แสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน  
ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิ PowerPoint ที่เป็นพื้นฐาน การแก้ไขสมุดงานผ่าน OLE ต้องการแอปพลิเคชันเดสก์ท็อปที่รองรับการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้  

## **ข้อกำหนดเบื้องต้น**

กำหนดค่าโครงการ C++ ของคุณด้วยไฟล์หัวเรื่องและไลบรารีสำหรับ Aspose.Cells for C++ และ Aspose.Slides for C++ ใส่โค้ดตัวอย่างลงในจุดเข้าของแอปพลิเคชันของคุณพร้อมการประกาศ include ในระดับไฟล์ Microsoft Office ไม่จำเป็นสำหรับการสร้างงานนำเสนอด้วยไลบรารีเหล่านี้  
ไม่ต้องใช้ไฟล์อินพุตใด ๆ: ตัวอย่างจะสร้างข้อมูลและแผนภูมิในหน่วยความจำ แล้วเขียน `OutputChart.pptx` ไปยังไดเรกทอรีทำงานปัจจุบัน ให้ใช้ใบอนุญาตสำหรับทั้งสองผลิตภัณฑ์เมื่อทำงานนอกโหมดประเมินผล  

## **วิธีการทำงานของการฝัง**

1. สร้างสมุดงานที่มีแผ่นงานข้อมูลและแผ่นแผนภูมิ  
1. ทำให้แผ่นแผนภูมิเป็นแผ่นที่เปิดใช้งานเพื่อให้สมุดงานเปิดที่แผนภูมิ  
1. ตั้งค่าช่วงการแสดงผล OLE ของสมุดงานและเรนเดอร์แผนภูมิเป็น PNG  
1. บันทึกสมุดงานเป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นลงในสไลด์  
1. กำหนด PNG เป็นพรีวิวของวัตถุ OLE และบันทึกงานนำเสนอเป็น PPTX  

ช่วงการแสดงผลของสมุดงานและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) ใช้ดัชนีแถวและคอลัมน์เริ่มต้น/สิ้นสุดที่เริ่มจากศูนย์ [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) แทนจะรับแถวบน, คอลัมน์ซ้าย, แถวล่างและคอลัมน์ขวา ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบล่างขวา ค่าต่าง ๆ เหล่านี้เป็นการเลือกการจัดวาง ไม่ใช่จำนวนแถวหรือคอลัมน์ของข้อมูล  
กรอบสไลด์ใช้หน่วยเป็นพิกัด จุด ตัวอย่างจะปรับให้พอดีกับสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG ไว้ แทนการขยายภาพพรีวิวให้เต็มสไลด์  

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มต่อไปนี้จะเติมข้อมูลใน `DataSheet` ด้วยค่าแถวสี่แถวและคอลัมน์ห้าคอลัมน์ แต่ละแถวจะกลายเป็นชุดข้อมูลของแผนภูมิ `ChartSheet` ถูกเลือกเป็นแผ่นที่เปิดใช้งานก่อนที่สมุดงานจะถูกบันทึก  

สมุดงานจะถูกบันทึกอย่างชัดเจนเป็น XLSX โดยสอดคล้องกับนามสกุล `xlsx` ที่ส่งผ่านให้กับ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) PNG จะถูกโหลดจากสตรีมในหน่วยความจำโดยไม่มีการแปลงบิตแมปกลาง Aspose.Cells จะคืนค่าเวกเตอร์ไบต์ ซึ่งตัวอย่างจะคัดลอกไปยังประเภทอาร์เรย์ที่รับโดย Aspose.Slides ให้ทำการเริ่มต้น Aspose.Cells ก่อนใช้วัตถุของมัน และปล่อยทรัพยากรหลังจากวัตถุเหล่านั้นถูกทำลาย การกำหนดผ่าน [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) จะแทนที่ภาพแทนที่ OLE เริ่มต้น  

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // เรนเดอร์พรีวิวแผนภูมิและทำการซีเรียลไลซ์สมุดงานที่แก้ไขได้แยกออกจากกัน.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // คัดลอกบัฟเฟอร์ของ Cells ไปยังอาร์เรย์ประเภทที่ Slides ใช้.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // ปรับพรีวิวให้พอดีภายในสไลด์โดยคงอัตราส่วนไว้.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// ปล่อยทรัพยากรของ Cells หลังจากอ็อบเจ็กต์ Cells ทั้งหมดถูกทำลายแล้ว.
Aspose::Cells::Cleanup();
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งที่ฝังสมุดงาน Excel และพรีวิวแผนภูมิ สมุดงานประกอบด้วยข้อมูลเดิมและแผนภูมิคอลัมน์ที่มีสี่ชุดข้อมูล พรีวิวถูกจัดกึ่งกลางบนสไลด์และรักษาอัตราส่วนของมันไว้  
![แผนภูมิคอลัมน์ของ Excel แสดงเป็นพรีวิวของสมุดงานที่ฝังอยู่](excel-chart-ole-preview.png)  
ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่รองรับและมี Excel ให้ใช้ได้ ให้คลิกสองครั้งที่วัตถุเพื่อเปิดใช้งานและแก้ไขสมุดงานที่ฝัง การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย  

## **คำถามที่พบบ่อย**

**ทำไมต้องมีภาพพรีวิว?**  
สมุดงานที่ฝังและพรีวิวบนสไลด์เป็นเนื้อหาแยกกัน ให้จัดเตรียมภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนที่ตัวแทนค่าเริ่มต้น "EMBEDDED OLE OBJECT" ดู [ปัญหาการพรีวิวของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/).  

**ภาพพรีวิวอัปเดตโดยอัตโนมัติหรือไม่เมื่อฉันเปลี่ยนสมุดงานในโค้ด?**  
ถือว่าพรีวิวเป็นสแนปช็อต เมื่ออัปเดตข้อมูลสมุดงานโดยโปรแกรม จะต้องสร้างภาพแผนภูมิใหม่และแทนที่พรีวิวรวมถึงข้อมูลสมุดงานที่ฝังด้วย  

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**  
ใช่ บันทึกสมุดงานในรูปแบบ XLS และใช้ `xls` เป็นนามสกุลข้อมูลที่ฝัง นามสกุลต้องตรงกับรูปแบบสมุดงานจริง; การเปลี่ยนนามสกุลเพียงอย่างเดียวไม่ทำให้ข้อมูลถูกแปลง  

**ทำไมวัตถุจึงอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**  
แอปพลิเคชันโฮสต์สามารถอัปเดตการนำเสนอของวัตถุ OLE เมื่อเปิดใช้งานสมุดงาน ช่วงการแสดงผล OLE ของสมุดงานและขนาดกรอบสไลด์มีความสำคัญทั้งสอง ดู [วิธีแก้ไขการปรับขนาดแผนภูมิใน PPTX](/slides/th/cpp/working-solution-for-chart-resizing-in-pptx/).  

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ไขการปรับขนาดแผนภูมิใน PPTX](/slides/th/cpp/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาการพรีวิวของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/)