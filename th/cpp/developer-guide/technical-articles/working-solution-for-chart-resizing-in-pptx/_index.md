---
title: โซลูชันการทำงานสำหรับการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 60
url: /th/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- วัตถุ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ Excel OLE ที่ฝังอยู่กับ Aspose.Slides for C++. ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดแผนภูมิและกรอบ OLE สอดคล้องกัน."
---
## **Background**

แผนภูมิ Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint โดยใช้คอมโพเนนต์ของ Aspose สามารถเปลี่ยนขนาดได้หลังจากการเปิดใช้งานครั้งแรก สิ่งนี้อาจทำให้เกิดความแตกต่างที่สังเกตได้ในลักษณะของแผนภูมิก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายเหตุผลที่เกิดการปรับขนาดและแสดงวิธีป้องกันโดยการจับคู่ขนาดแผนภูมิคงที่กับกรอบ OLE

ใน [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for C++ และฝังลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for C++. เพื่อแก้ไขปัญหา [object preview issue](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพแผนภูมิให้กับกรอบวัตถุ OLE ของแผนภูมิ. ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบวัตถุ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขเวิร์กบุ๊ก Excel ที่ฝังอยู่และจากนั้นกลับไปยังสไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ และปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดเดิมของกรอบวัตถุ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **Cause of Resizing**

เวิร์กบุ๊ก Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามรักษาขนาดนั้นเมื่อวัตถุถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดแยกออกมา เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน, Excel และ PowerPoint จะเจรจาขนาดของวัตถุเพื่อรักษาสัดส่วนเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างเวิร์กบุ๊กและกรอบ OLE จึงอาจทำให้วัตถุปรับขนาด

## **Working Solution**

จับคู่ขนาดแผนภูมิกับกรอบ OLE บนสไลด์และทำให้ขนาดแผนภูมิเป็นอิสระจากหน้าต่างเวิร์กบุ๊ก วิธีแก้ปัญหานี้ทำงานกับงานนำเสนอใหม่หรือเทมเพลตที่มีอยู่ ตัวอย่างนี้ต้องใช้ Aspose.Cells for C++ และ Aspose.Slides for C++. มันสร้างแผนภูมิคอลัมน์ง่ายบนแผ่นแผนภูมิที่ทำงานอยู่และฝังเวิร์กบุ๊กในรูปแบบ XLS ไม่มีการกำหนดภาพแสดงตัวอย่างของแผนภูมิ; แผนภูมิจะปรากฏเมื่อวัตถุ OLE ถูกเปิดใช้งานใน PowerPoint

วางโค้ดตัวอย่างในจุดเริ่มต้นของแอปพลิเคชันของคุณ โดยมีการประกาศ include ที่ระดับไฟล์ เริ่มต้น Aspose.Cells ก่อนสร้างอ็อบเจ็กต์ของมันและปลดปล่อยทรัพยากรหลังจากอ็อบเจ็กต์เหล่านั้นถูกทำลาย ตัวอย่างจะคัดลอกเวกเตอร์ไบต์ของเวิร์กบุ๊กที่ Aspose.Cells คืนค่าไปยังอาร์เรย์ประเภทที่ Aspose.Slides ยอมรับ

ตัวอย่างสร้างงานนำเสนอใหม่ที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว วางตำแหน่งห่างจากขอบซ้าย 0.5 นิ้วและจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์ใช้หน่วยพอยต์ (72 พอยต์ต่อหนึ่งนิ้ว) หากเป็นงานนำเสนอที่มีอยู่แล้ว ดูที่ [Use a Template](#use-a-template).

## **Set a Fixed Chart Size**

Set [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) to false so that the chart dimensions are independent of the workbook window. ตั้งค่า Chart::SetSizeWithWindow เป็น false เพื่อให้ขนาดแผนภูมิเป็นอิสระจากหน้าต่างเวิร์กบุ๊ก

Set the [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) dimensions through [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) and [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. ตั้งค่าขนาดของ Chart::GetChartObject ผ่าน Shape::SetWidth และ Shape::SetHeight โดยแปลงจากพอยต์เป็นพิกเซลโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่มีขนาด 684 × 288 พอยต์จะเทียบเท่ากับแผนภูมิขนาด 912 × 384 พิกเซล

Set [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) to the Custom value of [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). ตั้งค่า Chart::SetPrintSize ให้เป็นค่า Custom ของ PrintSizeType

The example embeds the workbook with [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) and saves a presentation with a 9.5 × 4-inch OLE frame. ตัวอย่างฝังเวิร์กบุ๊กด้วย IShapeCollection::AddOleObjectFrame และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // พิกัดและขนาดของสไลด์ใช้หน่วยพอยต์ (72 พอยต์ต่อหนึ่งนิ้ว).
    auto width = 684.f; // 9.5 นิ้ว.
    auto height = 288.f; // 4 นิ้ว.

    chart.SetSizeWithWindow(false);
    // แปลงพอยต์เป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // คัดลอกเวกเตอร์ไบต์ของ Cells ไปยังชนิดอาร์เรย์ที่ Slides ยอมรับ.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Use a Template**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่แล้ว เพื่อปรับตัวอย่างให้เข้ากับ:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
2. ตรวจสอบว่าหนังสือสไลด์แรกมีรูปร่างอย่างน้อยสามรูป แล้วใช้รูปร่างที่ดัชนี 2เป็นตำแหน่งตัวแทน
3. นำความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288. คำนวณขนาดให้คงเดิม
4. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวแทนแทนการใช้พิกัดคงที่ 36 และ 72
5. ลบตัวแทนก่อนบันทึกงานนำเสนอ

## **FAQ**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่ของฉันจึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**  
สิ่งนี้เกิดขึ้นเนื่องจาก Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก, ขณะที่กรอบวัตถุ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำอย่างไรให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกัน?**  
กำหนดขนาดแผนภูมิคงที่ที่ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิกำหนดเองก่อนฝังเวิร์กบุ๊ก ตัวอย่างข้างต้นแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การจับคู่ขนาดหน้าต่างเวิร์กบุ๊กเพียงอย่างเดียวเพียงพอหรือไม่?**  
การจับคู่ขนาดหน้าต่างเวิร์กบุ๊กเพียงอย่างเดียวไม่ได้ป้องกันการเปลี่ยนขนาดของกรอบ OLE หลังจากเปิดใช้งานอย่างเชื่อถือได้ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้ปัญหานี้ทำงานกับงานนำเสนอที่ใช้เทมเพลตและงานนำเสนอใหม่หรือไม่?**  
ใช่ สำหรับเทมเพลต ใช้ขนาดและตำแหน่งของตัวแทน สำหรับงานนำเสนอใหม่ ให้ระบุกรอบและตำแหน่งโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**  
ตัวอย่างใช้เวิร์กบุ๊ก Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **Related Sections**

- [สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)