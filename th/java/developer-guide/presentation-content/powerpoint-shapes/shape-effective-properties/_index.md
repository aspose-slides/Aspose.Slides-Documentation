---
title: รับคุณสมบัติรูปทรงที่มีผลจากการนำเสนอใน Java
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/java/shape-effective-properties/
keywords:
- คุณสมบัติรูปทรง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปทรงบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides for Java เพื่อแยกแยะการจัดรูปแบบรูปทรงที่เป็นท้องถิ่น, สืบทอด, และที่มีผลในงานนำเสนอ PowerPoint."
---
## **ทำความเข้าใจคุณสมบัติท้องถิ่น, สืบทอด, และที่มีผล**

การจัดรูปแบบ PowerPoint สามารถมาจากหลายแหล่ง ค่าที่เก็บโดยตรงบนอ็อบเจ็กต์คือ **ค่าท้องถิ่น** หากค่านั้นไม่ได้ตั้งค่า PowerPoint จะตรวจสอบแหล่งจัดรูปแบบของพาเรนท์ เช่น ค่ามาตรฐานของย่อหน้า สไตล์ข้อความ รูปแบบหรือมาสเตอร์สไลด์ ธีม หรือค่ามาตรฐานระดับการนำเสนอ ค่าต่าง ๆ เหล่านี้คือ **ค่าที่สืบทอด** ค่าที่เหลือหลังจากการแก้ไขลำดับชั้นทั้งหมดเรียกว่ **ค่าที่มีผล** — ค่าที่ใช้ในการแสดงผลอ็อบเจ็กต์

ตัวอย่างเช่น ส่วนข้อความอาจไม่ได้กำหนดความสูงของฟอนต์ของตนเอง ค่า **ท้องถิ่น** [getFontHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) จะเป็น `Float.NaN` ซึ่งหมายความว่า “ไม่ได้ตั้งค่านี้ที่นี่” ส่วนข้อความสามารถสืบทอดความสูงจากย่อหน้า สไตล์ข้อความมาตรฐานของการนำเสนอ หรือแหล่งอื่นที่ใช้ได้ การเรียก [getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/#getEffective--) บนรูปแบบส่วนจะคืนค่าความสูงที่แก้ไขแล้วสุดท้าย

ใช้ข้อมูลการจัดรูปแบบสองประเภทเพื่อวัตถุประสงค์ที่แตกต่างกัน:

- อ่านหรือเปลี่ยนอ็อบเจ็กต์รูปแบบท้องถิ่น เช่น [IPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/) เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ใด
- อ่านอ็อบเจ็กต์ข้อมูลที่มีผล เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformateffectivedata/) เมื่อคุณต้องการผลลัพธ์ที่แสดงขั้นสุดท้าย ข้อมูลที่มีผลเป็นแบบอ่าน‑อย่างเท่านั้น

## **เปรียบเทียบค่าท้องถิ่น, สืบทอด, และที่มีผล**

ตัวอย่างสมบัติต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนต์ในระดับการนำเสนอ, ย่อหน้า, และส่วนข้อความแต่ละขั้นตอนจะพิมพ์ค่าที่กำหนดไว้ที่ระดับนั้นและค่าที่มีผลสำหรับส่วนข้อความเดียวกัน นอกจากนี้ยังแสดงว่าทำไมต้องอ่านข้อมูลที่มีผลอีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบ

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

            // กำหนดค่าที่สืบทอดที่สองระดับแตกต่างกัน.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // ค่าท้องถิ่นบนส่วนข้อความจะทับค่าที่สืบทอดทั้งสองค่า.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // ล้างค่าท้องถิ่น. ส่วนข้อความจะสืบทอดจากย่อหน้าต่อไป.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // ล้างค่าของย่อหน้า. ค่าตั้งต้นของการนำเสนอจะเป็นผลลัพธ์ตอนนี้.
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

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบท้องถิ่นของส่วนข้อความเป็นอันดับแรก, ตามด้วยการจัดรูปแบบของย่อหน้า, แล้วจึงตามด้วยค่ามาตรฐานของการนำเสนอ วัตถุอื่นอาจมีสายการสืบทอดที่ต่างกัน แต่หลักการเดียวกัน: ค่าที่ระบุโดยเฉพาะเจาะจงที่สุดจะชนะและ [getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/#getEffective--) จะคืนค่าผลลัพธ์สุดท้าย

## **รับคุณสมบัติข้อความที่มีผล**

การจัดรูปแบบข้อความถูกกระจายไปหลายอ็อบเจ็กต์:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#getEffective--) แก้ไขคุณสมบัติกรอบข้อความเช่น ระยะขอบ, การยึด, การปรับอัตโนมัติ, และทิศทางข้อความแนวตั้ง
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextstyle/#getEffective--) แก้ไขการจัดรูปแบบย่อหน้าสำหรับแต่ละระดับสไตล์ข้อความ
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getEffective--) แก้ไขคุณสมบัติย่อหน้าเช่น การจัดแนว, การเยื้อง, และสัญลักษณ์หัวข้อ
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/#getEffective--) แก้ไขคุณสมบัติตัวอักษรเช่น ความสูงของฟอนต์, ชนิดตัวอักษร, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างถัดไป `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) ที่มีกรอบข้อความไม่ว่างเปล่า AutoShape สามารถอยู่ตำแหน่งใดก็ได้ในคอลเลกชันรูปทรง; โค้ดจะค้นหาอ็อบเจ็กต์ที่เหมาะสมและตรวจสอบความถูกต้องก่อนใช้งาน

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

## **รับคุณสมบัติ 3D ที่มีผล**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getEffective--) คืนค่าอ็อบเจ็กต์ [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformateffectivedata/) หนึ่งตัวที่รวมการตั้งค่า 3D ทั้งหมดที่แก้ไขแล้ว วิธีการ [getCamera](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), และ [getBevelBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) เปิดเผยข้อมูลที่มีผลที่สอดคล้องกัน การอ่านการตั้งค่าเหล่านี้พร้อมกันทำให้เข้าใจลักษณะ 3D สุดท้ายของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้ `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรก หากต้องการให้ผลลัพธ์มีค่าอื่นนอกจากค่าเริ่มต้น ให้กำหนดกล้อง 3D, การจัดแสง, หรือการตั้งค่า bevel ให้กับรูปทรงนั้น

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

## **รับการจัดรูปแบบตารางที่มีผล**

การจัดรูปแบบตารางสามารถมาจากสไตล์ตารางและจากการกำหนดรูปแบบที่ใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์แต่ละเซลล์ สำหรับความขัดแย้งระหว่างการเติมสีที่กำหนดโดยชัดเจน ลำดับความสำคัญคือเซลล์, แถว, คอลัมน์, แล้วจึงเป็นตารางทั้งหมด รูปแบบที่มีผลของเซลล์คือรูปแบบสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้ `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/itable/) แทนการสมมติว่า `getShapes().get_Item(0)` เป็นตาราง

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

หากต้องการสีแทนที่จะเป็นประเภทการเติมเท่านั้น ให้ตรวจสอบ [getFillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) ของข้อมูลที่มีผลก่อน จากนั้นอ่านวิธีที่เกี่ยวข้องกับประเภทนั้น—for example, [getSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) สำหรับการเติมสีทึบ

## **อ่านข้อมูลที่มีผลอีกครั้งหลังการเปลี่ยนแปลง**

ข้อมูลที่มีผลอธิบายลำดับชั้นการจัดรูปแบบในขณะที่ถูกแก้ไข เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจมีส่วนร่วมในลำดับชั้นนั้น รวมถึง:

- การจัดรูปแบบท้องถิ่นของอ็อบเจ็กต์
- ค่ามาตรฐานของย่อหน้าหรือกรอบข้อความ
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือรูปแบบเซลล์
- การจัดรูปแบบของเลย์เอาต์หรือมาสเตอร์สไลด์
- ข้อมูลธีมหรือค่ามาตรฐานระดับการนำเสนอ
- เลย์เอาต์หรือมาสเตอร์ที่กำหนดให้สไลด์

ห้ามเก็บอ็อบเจ็กต์ข้อมูลที่มีผลเป็นสแนปช็อตถาวร Aspose.Slides อาจแคชข้อมูลที่มีผลบางอย่างภายในและการเรียก `getEffective` ภายหลังอาจรีเฟรชข้อมูลนั้น หากต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง ให้คัดลอกค่าตัวเลขที่ต้องการ—เช่น ความสูงของฟอนต์, สี, การจัดแนว, หรือความกว้างของ bevel—ไปยังตัวแปรของคุณก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า ให้อัปเดตอ็อบเจ็กต์รูปแบบท้องถิ่นที่เหมาะสมแล้วเรียก `getEffective` เพื่อตรวจสอบผลลัพธ์เอง ข้อมูลที่มีผลเองเป็นแบบอ่าน‑อย่างเท่านั้น

## **FAQ**

**ฉันจะทราบว่าระดับใดเป็นผู้ให้ค่าที่มีผล?**

ข้อมูลที่มีผลมีค่าขั้นสุดท้าย ไม่ได้บอกแหล่งที่มา ตรวจสอบอ็อบเจ็กต์ท้องถิ่นที่ใช้จากระดับที่เฉพาะที่สุดออกไป สำหรับข้อความอาจรวมถึงส่วนข้อความ, ย่อหน้า, กรอบข้อความ, เลย์เอาต์, มาสเตอร์, ธีม, และค่ามาตรฐานของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `Float.NaN` หรือ `null` บ่งบอกว่าการค้นหายังคงดำเนินต่อไปยังระดับอื่น

**จะเกิดอะไรขึ้นเมื่อไม่มีระดับใดกำหนดคุณสมบัติ?**

Aspose.Slides จะใช้ค่าเริ่มต้นของ PowerPoint หรือของไลบรารีที่เหมาะสม ค่าที่แก้ไขนี้จะปรากฏในข้อมูลที่มีผลแม้ว่าจะไม่มีอ็อบเจ็กต์ท้องถิ่นใดกำหนดโดยตรง

**ทำไมค่าที่มีผลบางครั้งจึงเท่ากับค่าท้องถิ่น?**

ค่าท้องถิ่นชนะในการคำนวนสืบทอด ซึ่งเป็นสิ่งที่คาดหวังเมื่อคุณสมบัตุถูกตั้งค่าชัดเจนบนอ็อบเจ็กต์และไม่มีกฎที่เจาะจงมากกว่ามาแทนที่มัน

**ควรใช้ข้อมูลท้องถิ่นแทนข้อมูลที่มีผลเมื่อใด?**

ใช้ข้อมูลท้องถิ่นเพื่อสืบค้นหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูลที่มีผลเมื่อคุณต้องการลักษณะการแสดงผลสุดท้ายหลังจากสืบทอด, กฎธีม, และสไตล์ที่เกี่ยวข้องทั้งหมดถูกแก้ไข ตัวอย่างการเปรียบเทียบสมบูรณ์ ([complete comparison example](#compare-local-inherited-and-effective-values)) แสดงทั้งสองกรณีในเวิร์กโฟลว์เดียวกัน