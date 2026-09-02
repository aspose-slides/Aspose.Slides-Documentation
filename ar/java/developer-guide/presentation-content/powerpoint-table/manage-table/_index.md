---
title: "إدارة جداول العروض التقديمية في Java"
linktitle: "إدارة الجدول"
type: docs
weight: 10
url: /ar/java/manage-table/
keywords:
- "إضافة جدول"
- "إنشاء جدول"
- "الوصول إلى جدول"
- "نسبة العرض إلى الارتفاع"
- "محاذاة النص"
- "تنسيق النص"
- "نمط الجدول"
- "PowerPoint"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للغة Java. اكتشف أمثلة شفرة بسيطة لتبسيط عمليات العمل مع الجداول."
---
## **مقدمة**

جدول في PowerPoint هو طريقة فعالة لعرض وتقديم المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) تكون واضحة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Table) والواجهة [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) والفئة [Cell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/) وأنواعًا أخرى لتسمح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية. 

## **إنشاء جدول من الصفر**

1. إنشاء مثال (كائن) من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. تجول عبر كل [ICell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمنى واليسرى.
7. ادمج الخليتين الأوليين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/). 
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/).
10. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة Java كيفية إنشاء جدول في عرض تقديمي:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تحديد الأعمدة بأعرضها والصفوف بارتفاعها
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // دمج الخلية 1 و 2 في الصف الأول
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // إضافة نص إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // حفظ العرض التقديمي إلى القرص
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ومبنيًا على الصفر. تُرقم الخلية الأولى في الجدول كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يضم 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يوضح لك هذا الكود بلغة Java كيفية تحديد ترقيم الخلايا في جدول:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بأعرضها والصفوف بارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // يحفظ العرض التقديمي إلى القرص
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى جدول موجود**

1. إنشاء مثال (كائن) من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة التي تحتوي على الجدول عبر فهرستها. 
3. أنشئ كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) وضعه كقيمة null.
4. تجول عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) حتى يتم العثور على الجدول.  
   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يُحدد شكل كجدول، يمكنك تحويل نوعه إلى كائن [Table](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Table). لكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فالأفضل البحث عن الجدول المطلوب عبر خاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).
5. استخدم كائن [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة Java كيفية الوصول إلى جدول موجود والعمل معه:

```java
import com.aspose.slides.*;

// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يهيئ TableEx إلى null
    ITable tbl = null;

    // يتنقل عبر الأشكال ويحدد مرجعًا للجدول الموجود
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // يضبط النص للعمود الأول من الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // يحفظ العرض التقديمي المعدل إلى القرص
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **العثور على الخلية التي تملك إطار نص**

عند استلام كود معالجة نص عام كائن [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) من جدول، استخدم طريقة [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) لاسترجاع [ICell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/) المالك. لإطار نص خلية جدول، تُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) المالك وتُعيد [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentShape--) قيمة `null`، على الرغم من أن الجدول نفسه يُعتبر شكلًا.

إحداثيات الخلية متاحة عبر طرق القراءة فقط [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/#getFirstColumnIndex--) و[ICell.getFirstRowIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/#getFirstRowIndex--). كما تُوفر [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) تنقلًا للقراءة فقط: تُعيد المالك دون تعديل الملكية. تأكد دائمًا من فحص الخلية المرجعة للتأكد من أنها ليست `null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/java/search-and-replace-text/).

## **محاذاة النص في جدول**

1. إنشاء مثال (كائن) من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) إلى الشريحة. 
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) من الجدول. 
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
6. محاذاة النص عموديًا.
7. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة Java كيفية محاذاة النص في جدول:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحدد الأعمدة بأعرضها والصفوف بارتفاعها
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // يضيف شكل الجدول إلى الشريحة
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // يفتح إطار النص
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // ينشئ كائن الفقرة لإطار النص
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // ينشئ كائن الجزء للفقرة
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // محاذاة النص عموديًا
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // يحفظ العرض التقديمي إلى القرص
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثال (كائن) من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable) من الشريحة.
4. ضبط [setFontHeight(float value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للخط. 
5. ضبط [setAlignment(int value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. ضبط [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. احفظ العرض التقديمي المعدل. 

يوضح لك هذا الكود بلغة Java كيفية تطبيق خيارات التنسيق المفضلة على النص داخل جدول:

```java
import com.aspose.slides.*;

// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // يحدد ارتفاع خط خلايا الجدول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // يحدد محاذاة نص خلايا الجدول والهامش الأيمن في مكالمة واحدة
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // يحدد النوع العمودي لنص خلايا الجدول
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود بلغة Java كيفية الحصول على خصائص النمط من نمط جدول محدد مسبقًا:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير نمط القالب الافتراضي للجدول

    // يحصل على نمط القالب للجدول
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // يطبق نمط القالب المستخرج على جدول آخر
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أبعاده المختلفة. قدمت Aspose.Slides خاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) لتسمح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول وغيرها من الأشكال. 

يوضح لك هذا الكود بلغة Java كيفية قفل نسبة العرض إلى الارتفاع لجدول:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // عكس

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتداولة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يعرض الجدول الطريقة [setRightToLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/table/#setRightToLeft-boolean-)، وتحتوي الفقرات على [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). باستخدام كلاهما يضمن الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/java/applying-protection-to-presentation/) لتعطيل التحريك، وتغيير الحجم، والتحديد، وما إلى ذلك. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تقسيم).