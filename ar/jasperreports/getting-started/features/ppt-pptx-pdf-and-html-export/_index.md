---
title: تصدير PPT، PPTX، PDF و HTML
type: docs
weight: 20
url: /ar/jasperreports/ppt-pptx-pdf-and-html-export/
description: "اختر المصدِّر Aspose.Slides لـ JasperReports للحصول على مخرجات PPT أو PPTX أو PDF أو HTML، صدّر تقريرًا مملوءًا باستخدامه، وقم بربط خطوط التقرير بخطوط العرض التقديمي."
---
## **المصدِّرات**

تضيف Aspose.Slides لـ JasperReports أربع مصدِّرات إلى JasperReports. كل واحد يأخذ تقريرًا مملوءًا (`JasperPrint`) ويصدّر كل صفحة من التقرير: كشريحة في PPT و PPTX، كصفحة في PDF، وكصورة SVG في ملف HTML واحد.

| صيغة الإخراج | فئة المصدِّر |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

الفئات موجودة في حزمة `com.aspose.slides.jasperreports` داخل ملف jar الخاص بالمكتبة، ولا تستخدم Microsoft PowerPoint. مرّر التقرير وملف الإخراج إلى المصدِّر باستخدام `setParameter` و `JRExporterParameter`، والتي تصنفها JasperReports كمهملة: المصدِّرات لا تقبل تكوين `setExporterInput` و `setExporterOutput` الجديد.

## **تصدير تقرير إلى جميع الصيغ الأربع**

البرنامج أدناه يبني على المشروع من [تصديرك الأول](/slides/ar/jasperreports/#your-first-export). يقوم بتجميع وملء *hello.jrxml* مرة واحدة، ثم يمرر التقرير المملوء إلى كل مصدِّر على حدة. احفظه كملف *src/main/java/ExportAllFormats.java* في ذلك المشروع:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // قم بتجميع وملء التقرير مرة واحدة.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // صدّر التقرير المملوء نفسه باستخدام كل مصدر.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

شغّله من مجلد المشروع:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

يقوم البرنامج بحفظ *hello.ppt* و *hello.pptx* و *hello.pdf* و *hello.html* في مجلد المشروع. الطريقة المساعدة تأخذ `ASAbstractExporter`، الفئة الأساسية لكل الأربعة مصدِّرات. بدون ترخيص، كل ملف إخراج يحمل علامة مائية للتقييم — راجع [تقييم Aspose.Slides](/slides/ar/jasperreports/evaluate-aspose-slides/).

![تقرير تم تصديره إلى عرض تقديمي بدون ترخيص](ppt-pptx-pdf-and-html-export_1.png)

## **تعيين الخطوط**

المصدِّرات PPT و PPTX تكتب أسماء الخطوط في تصميم التقرير إلى العرض التقديمي دون تعديل. عندما لا يحدد عنصر نص أي خط، يستخدم JasperReports الخط الافتراضي الخاص به، `SansSerif`، وهو اسم خط منطقي في Java وليس خطًا مثبتًا. لاستبدال هذه الأسماء، مرّر خريطة من أسماء خطوط التقرير إلى أسماء الخطوط التي تريدها في العرض التقديمي عبر معامل `ASExporterParameters.PPT_FONT_MAP`. يجب أن تتطابق المفاتيح مع أسماء الخطوط في التقرير تمامًا، بما في ذلك حالة الأحرف. يجب أن يكون كل قيمة خطًا تجده Java على الجهاز الذي يجري التصدير؛ تتجاهل المصدِّرات الإدخال الذي لا يجد Java الخط فيه.

احفظ هذا البرنامج كملف *src/main/java/MapFonts.java* في نفس المشروع. يقوم بتصدير *hello.jrxml* إلى PPTX مع استبدال `SansSerif` بـ Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // ربط اسم خط التقرير بالخط الذي سيُكتب في العرض التقديمي.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

شغّله من مجلد المشروع:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

في ملف *hello-arial.pptx* المحفوظ، يستخدم نص التقرير الخط Arial بدلًا من `SansSerif`. على جهاز لا يجده Java Arial، مثل نظام Linux الذي لا يحتويه، يبقى النص بـ `SansSerif`. على JasperReports Server، عيّن نفس الخريطة عبر خاصية `fontMap` لكائن bean الخاص بمعاملات التصدير — راجع [التكامل مع JasperServer](/slides/ar/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).