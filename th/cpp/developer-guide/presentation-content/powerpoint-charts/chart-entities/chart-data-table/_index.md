---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอโดยใช้ C++
linktitle: ตารางข้อมูล
type: docs
url: /th/cpp/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติแบบอักษร
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งแบบอักษร, เส้นขอบ, และกุญแจคำอธิบายภาพของตารางข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ ให้คุณแสดงตารางข้อมูลของแผนภูมิและปรับแต่งรูปแบบข้อความ, เส้นขอบ, และกุญแจคำอธิบายภาพ. บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมประเภทของเส้นขอบแต่ละประเภท, และแสดงหรือซ่อนกุญแจคำอธิบายภาพ. ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้ในไฟล์ PPTX.

## **ตั้งค่าแบบอักษร**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ส่งค่า `true` ไปยัง [IChart::set_HasDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_hasdatatable/). ใช้ [IChart::get_ChartDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdatatable/) เพื่อเข้าถึงตารางและกำหนดรูปแบบข้อความของมัน.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มลงในสไลด์แรก.
3. เปิดใช้งานตารางข้อมูลของแผนภูมิ.
4. เปิดใช้งานข้อความหนาด้วย [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_fontbold/) และส่งค่า `20` ไปยัง [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_fontheight/) เพื่อกำหนดข้อความขนาด 20 จุด.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างต่อไปนี้ต้องการไฟล์ `test.pptx` อยู่ในไดเรกทอรีทำงานโดยมีอย่างน้อยหนึ่งสไลด์. ตัวอย่างจะเพิ่มแผนภูมิพร้อมข้อมูลตั้งต้นที่ตำแหน่ง (50, 50) ความกว้าง 600 จุดและความสูง 400 จุด. ไฟล์ `output.pptx` ที่บันทึกไว้จะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและการตั้งค่าแบบอักษรที่ระบุ.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **กำหนดแต่งเส้นขอบของตารางข้อมูล**

เปิดใช้งานตารางด้วย [IChart::set_HasDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_hasdatatable/) และเข้าถึงมันผ่าน [IChart::get_ChartDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdatatable/). คุณสามารถควบคุมเส้นขอบสามประเภทได้อย่างอิสระ:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) ควบคุมเส้นขอบเซลล์แนวนอน.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) ควบคุมเส้นขอบเซลล์แนวตั้ง.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) ควบคุมเส้นขอบนอกของตาราง.

ส่งค่า `true` ไปยังตัวตั้งค่าแต่ละตัวเพื่อแสดงเส้นขอบหรือ `false` เพื่อซ่อนเส้นขอบ. ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลตั้งต้น, แสดงเส้นขอบแนวนอนและเส้นขอบนอก, และซ่อนเส้นขอบแนวตั้ง. ไม่ต้องใช้ไฟล์อินพุตใด ๆ. ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิและการตั้งค่ากุญแจคำอธิบายภาพเดียวกันในสี่กรณี. เริ่มจากเปิดใช้งานเส้นขอบทั้งหมด, แต่ละเวอร์ชันที่เหลือจะปิดการตั้งค่าเส้นขอบเพียงหนึ่งประเภท. เวอร์ชันด้านล่างซ้ายตรงกับการตั้งค่าเส้นขอบในตัวอย่าง.

![ตารางข้อมูลแผนภูมิที่มีเส้นขอบทั้งหมดเปิดใช้งาน, ไม่มีเส้นขอบแนวนอน, ไม่มีเส้นขอบแนวตั้ง, และไม่มีเส้นขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนกุญแจคำอธิบายภาพ**

กุญแจคำอธิบายภาพคือเครื่องหมายสีเล็ก ๆ อยู่ข้างชื่อชุดข้อมูลในตารางข้อมูล. พวกมันช่วยให้ผู้อ่านจับคู่แถวของตารางกับชุดข้อมูลของแผนภูมิ. ส่งค่า `true` ไปยัง [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) เพื่อแสดงเครื่องหมายเหล่านี้หรือ `false` เพื่อซ่อน.

คำอธิบายภาพแยกของแผนภูมิควบคุมด้วย [IChart::set_HasLegend](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_haslegend/). การตั้งค่าเหล่านี้เป็นอิสระ: การซ่อนคำอธิบายภาพแยกไม่ทำให้กุญแจในตารางข้อมูลหายไป, และการซ่อนกุญแจในตารางไม่ทำให้คำอธิบายภาพแยกหายไป.

ตัวอย่างต่อไปนี้สร้างแผนภูมิพร้อมข้อมูลตั้งต้น, เปิดใช้งานตารางข้อมูล, และแสดงกุญแจคำอธิบายภาพภายในตารางขณะซ่อนคำอธิบายภาพแยก. เส้นขอบของตารางทั้งหมดเปิดใช้งานอย่างชัดเจน. ไม่ต้องใช้งานนำเสนออินพุต. หากต้องการซ่อนกุญแจของตารางเท่านั้น, ส่งค่า `false` ไปยัง [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดกุญแจคำอธิบายภาพ. เส้นขอบทั้งหมดคงเปิดอยู่, และคำอธิบายภาพแยกของแผนภูมิซ่อนในทั้งสองกรณี.

![ตารางข้อมูลแผนภูมิที่มีกุญแจคำอธิบายภาพแสดงที่ด้านซ้ายและซ่อนที่ด้านขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงกุญแจคำอธิบายภาพในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่. ส่งค่า `true` ไปยัง [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) เพื่อแสดงกุญแจคำอธิบายภาพหรือ `false` เพื่อซ่อน.

**ตารางข้อมูลจะถูกเก็บไว้เมื่อนำงานนำเสนอออกเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่. Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/th/cpp/convert-powerpoint-to-html/), หรือ [รูปภาพ](/slides/th/cpp/convert-powerpoint-to-png/).

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดจากเทมเพลตได้หรือไม่?**

ใช่. สำหรับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่, ใช้ [IChart::get_HasDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_hasdatatable/) เพื่อตรวจสอบว่าตารางข้อมูลถูกแสดงหรือไม่และใช้ [IChart::set_HasDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_hasdatatable/) เพื่อเปลี่ยนการมองเห็น.

**ฉันจะหาผลลัพธ์แผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

วนลูปผ่านรูปร่างบนแต่ละสไลด์, ระบุแผนภูมิ, และตรวจสอบผลของ [IChart::get_HasDataTable](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_hasdatatable/). ค่า `true` หมายถึงตารางข้อมูลเปิดใช้งาน.