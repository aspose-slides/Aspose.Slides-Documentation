---
title: รับคุณสมบัติ Shape ที่มีผลจากการนำเสนอบน Android
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/androidjava/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างเบเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนท์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อแยกแยะการจัดรูปแบบรูปร่างแบบ local, inherited, และ effective ในการนำเสนอ PowerPoint."
---
## **ทำความเข้าใจ Local, Inherited, และ Effective Properties**

การจัดรูปแบบของ PowerPoint สามารถมาจากหลายแหล่ง ค่าที่เก็บโดยตรงบนอ็อบเจ็กต์คือ **local value**. หากค่านั้นไม่ได้ตั้งค่า PowerPoint จะตรวจสอบแหล่งกำหนดรูปแบบของพาเรนท์ เช่น ค่าเริ่มต้นของย่อหน้า, สไตล์ข้อความ, เลย์เอาต์หรือสไลด์มาสเตอร์, ธีม, หรือค่าเริ่มต้นระดับการนำเสนอ ค่านั้นเป็น **inherited values**. ค่าที่เหลือหลังจากลำดับชั้นทั้งหมดถูกแก้ไขคือ **effective value** — ค่าที่ใช้ในการแสดงอ็อบเจ็กต์.

ตัวอย่างเช่น ส่วนข้อความอาจไม่ได้กำหนดความสูงของฟอนท์ของตนเอง ค่า **local** ของ [getFontHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) จะเป็น `Float.NaN` ซึ่งหมายถึง “ไม่ได้ตั้งค่าไว้ที่นี่” ส่วนข้อความสามารถสืบทอดความสูงจากย่อหน้า, สไตล์ข้อความเริ่มต้นของการนำเสนอ, หรือแหล่งอื่นที่เกี่ยวข้อง การเรียกใช้ [getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/#getEffective--) บนรูปแบบส่วนข้อความจะคืนค่าความสูงที่แก้ไขขั้นสุดท้าย.

ใช้ข้อมูลการจัดรูปแบบสองประเภทสำหรับวัตถุประสงค์ที่แตกต่างกัน:

- อ่านหรือเปลี่ยนอ็อบเจ็กต์รูปแบบ **local** เช่น [IPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/), เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ใด
- อ่านอ็อบเจ็กต์ข้อมูล **effective** เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformateffectivedata/), เมื่อคุณต้องการผลลัพธ์ที่เรนเดอร์ขั้นสุดท้าย ข้อมูล effective เป็นแบบอ่านอย่างเดียว

## **เปรียบเทียบ Local, Inherited, และ Effective Values**

ตัวอย่างเต็มต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนท์ในระดับการนำเสนอ, ย่อหน้า, และส่วนข้อความ แต่ละขั้นจะพิมพ์ค่าที่กำหนดในระดับเหล่านั้นและค่าที่มีผลที่ได้จากส่วนข้อความเดียวกัน นอกจากนี้ยังแสดงเหตุผลว่าทำไมต้องอ่านข้อมูล effective อีกครั้งหลังจากการเปลี่ยนแปลงการจัดรูปแบบ

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // กำหนดค่าที่สืบทอดไว้ในสองระดับที่แตกต่างกัน.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // ค่าท้องถิ่นบน portion จะทับค่าที่สืบทอดทั้งสองค่า.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // ลบค่าท้องถิ่นออก ตอนนี้ portion จะสืบทอดจากย่อหน้าอีกครั้ง.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // ลบค่าของย่อหน้าออก ค่าตั้งต้นของการนำเสนอจะเป็นผลลัพธ์ตอนนี้.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // อ่านข้อมูลที่มีผลหลังจากการเปลี่ยนแปลงก่อนหน้า.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบ **local** ของส่วนข้อความก่อน, ตามด้วยการจัดรูปแบบของย่อหน้า, แล้วจึงตามค่าเริ่มต้นของการนำเสนอ วัตถุอื่นอาจมีโซ่การสืบทอดที่ต่างกัน แต่หลักการเหมือนเดิม: ค่าที่ระบุอย่างเฉพาะเจาะจงมากกว่าจะชนะ, และ [getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/#getEffective--) จะคืนผลลัพธ์ขั้นสุดท้าย

## **Get Effective Text Properties**

การจัดรูปแบบข้อความถูกแบ่งออกเป็นหลายอ็อบเจ็กต์:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#getEffective--) แก้ไขคุณสมบัติของกรอบข้อความ เช่น ระยะขอบ, การยึด, การปรับอัตโนมัติ, และทิศทางข้อความแนวตั้ง
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextstyle/#getEffective--) แก้ไขการจัดรูปแบบของย่อหน้าสำหรับแต่ละระดับของสไตล์ข้อความ
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) แก้ไขคุณสมบัติของย่อหน้า เช่น การจัดแนว, การเยื้อง, และจุดหัวข้อ
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/#getEffective--) แก้ไขคุณสมบัติของอักขระ เช่น ความสูงของฟอนท์, แบบอักษร, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างต่อไป, ไฟล์ `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) ที่มีกรอบข้อความไม่ว่างเปล่า AutoShape สามารถปรากฏได้ในตำแหน่งใด ๆ ของคอลเลกชันรูปทรง; โค้ดจะค้นหาอ็อบเจ็กต์ที่เหมาะสมและตรวจสอบความถูกต้องก่อนใช้งาน

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Get Effective 3D Properties**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getEffective--) คืนค่าอ็อบเจ็กต์ [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/) หนึ่งอันที่รวมการตั้งค่า 3 มิติที่แก้ไขทั้งหมด เมธอด [getCamera](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), และ [getBevelBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) จะเปิดเผยข้อมูล effective ที่สอดคล้อง การอ่านการตั้งค่าเหล่านี้พร้อมกันทำให้เข้าใจลักษณะ 3 มิติขั้นสุดท้ายของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้, ไฟล์ `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรก หากต้องการให้ผลลัพธ์มีค่าต่างจากค่าเริ่มต้น ให้กำหนดกล้อง 3 มิติ, แสง, หรือการตั้งค่า bevel ให้กับรูปทรงนั้น

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Get Effective Table Formatting**

การจัดรูปแบบตารางสามารถมาจากสไตล์ตารางและจากการกำหนดรูปแบบที่นำไปใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์แต่ละเซลล์ สำหรับความขัดแย้งระหว่างการเติมสีที่กำหนดอย่างชัดเจน ความสำคัญคือ เซลล์, แถว, คอลัมน์, แล้วจึงทั้งตาราง รูปแบบ effective ของเซลล์คือรูปแบบขั้นสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้, ไฟล์ `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดค้นหา [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/) แทนที่จะสมมติว่า `getShapes().get_Item(0)` เป็นตาราง

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

หากคุณต้องการสีแทนประเภทการเติมเพียงอย่างเดียว ให้ตรวจสอบ [getFillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) ของข้อมูล effective ก่อน, จากนั้นอ่านเมธอดที่สอดคล้องกับประเภทนั้น—for ตัวอย่าง, [getSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) สำหรับการเติมสีแบบทึบ

## **Re-read Effective Data After Changes**

ข้อมูล effective อธิบายลำดับชั้นการจัดรูปแบบในขณะที่ถูกแก้ไข เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจมีส่วนร่วมในลำดับชั้นนั้น, รวมถึง:

- การจัดรูปแบบ **local** ของอ็อบเจ็กต์
- ค่าเริ่มต้นของย่อหน้า หรือกรอบข้อความ
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือรูปแบบเซลล์
- การจัดรูปแบบของเลย์เอาต์หรือสไลด์มาสเตอร์
- ข้อมูลธีมหรือค่าเริ่มต้นระดับการนำเสนอ
- เลย์เอาต์หรือมาสเตอร์ที่กำหนดให้สไลด์

อย่าเก็บอ็อบเจ็กต์ข้อมูล effective ไว้เป็นสแนปช็อตถาวร Aspose.Slides อาจแคชข้อมูล effective บางส่วนภายใน, และการเรียก `getEffective` ครั้งต่อมาสามารถรีเฟรชข้อมูลนั้นได้ หากคุณต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง ใหคัดลึกค่าที่ต้องการ—เช่น ความสูงของฟอนท์, สี, การจัดแนว, หรือความกว้างของ bevel—ไปยังตัวแปรของคุณเองก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า, ปรับอ็อบเจ็กต์รูปแบบ **local** ที่เหมาะสมแล้วเรียก `getEffective` เพื่อตรวจสอบผลลัพธ์ ข้อมูล effective เองเป็นแบบอ่านอย่างเดียว

## **FAQ**

**ฉันจะรู้ได้อย่างไรว่าระดับใดเป็นผู้จัดหา value ที่ effective?**

ข้อมูล effective มีเพียงค่าขั้นสุดท้าย ไม่ได้บอกแหล่งที่มา ตรวจสอบอ็อบเจ็กต์ **local** ที่เกี่ยวข้องจากระดับที่เจาะจงที่สุดออกไป สำหรับข้อความอาจรวมถึง portion, paragraph, text frame, layout, master, theme, และค่าเริ่มต้นของการนำเสนอ ค่าที่เป็น `Float.NaN` หรือ `null` แสดงว่าการค้นหายังคงดำเนินต่อไปในระดับอื่น

**จะเกิดอะไรขึ้นถ้าไม่มีระดับใดกำหนด property นั้น?**

Aspose.Slides จะใช้ค่าเริ่มต้นของ PowerPoint หรือของไลบรารี ค่า resolve นี้จะปรากฏในข้อมูล effective แม้ว่าจะไม่มีอ็อบเจ็กต์ **local** กำหนดโดยตรง

**ทำไมบางครั้งค่า effective จึงเท่ากับค่า local?**

ค่า local ชนะการคำนวณการสืบทอด นี่เป็นพฤติกรรมปกติเมื่อ property ถูกตั้งค่าโดยตรงบนอ็อบเจ็กต์และไม่มีกฎที่เฉพาะเจาะจงมากกว่าเข้ามาแทนที่

**ควรใช้ข้อมูล local แทนข้อมูล effective เมื่อใด?**

ใช้ข้อมูล local เพื่อสอบถามหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูล effective เมื่อคุณต้องการรูปลักษณ์สุดท้ายหลังจากการสืบทอด, กฎธีม, และสไตล์ที่เกี่ยวข้องทั้งหมดถูกแก้ไข ตัวอย่างเปรียบเทียบที่ครบถ้วน ([complete comparison example](#compare-local-inherited-and-effective-values)) แสดงการใช้ทั้งสองแบบใน workflow เดียวกัน.