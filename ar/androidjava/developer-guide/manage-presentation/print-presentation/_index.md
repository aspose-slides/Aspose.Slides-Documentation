---
title: طباعة العرض التقديمي
type: docs
weight: 50
url: /ar/androidjava/print-presentation/
keywords: "طباعة بوربوينت, PPT, PPTX, طباعة عرض تقديمي, Java, طابعة, PrinterJob, PrintService"
description: "طباعة عرض تقديمي بوربوينت في Java"
---

في Aspose.Slides لـ Android عبر Java 24.4، قدمنا [API حديث](https://docs.aspose.com/slides/androidjava/modern-api/) يحد من دعم الطباعة. ومع ذلك، لقد اتخذنا نهجًا جديدًا لمساعدتك في التغلب على هذا القيد. في هذه المقالة، سنوضح لك كيفية طباعة عرض تقديمي باستخدام API الحالي.

## طباعة العرض التقديمي

تظهر مقتطفات الكود Java التالية كيفية طباعة عرض تقديمي بوربوينت باستخدام Aspose.Slides لـ Android عبر API Java.

لطباعة عرض تقديمي، اتبع الخطوات التالية:

1. أنشئ مثيلًا من `PrintRequestAttributeSet` وحدد سمات الطباعة مثل الاتجاه ونطاق الصفحات.
2. أنشئ مثيلًا من `RenderingOptions` وحدد الخيارات لتخطيط ملاحظات الشرائح.
3. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class، مع تحديد ملف العرض التقديمي.
4. أنشئ مثيلًا من `PrinterJob` لتحديد الطابعة المرغوبة.
5. قم بتوليد مصفوفة من صور الشرائح باستخدام [getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) method.
6. قم بضبط مصفوفة `IImage` كقابل للطباعة لـ `PrinterJob`.
7. استدعاء `print` method من فئة `PrinterJob`.

تأكد من استبدال **"printerName"** باسم الطابعة المحددة الخاصة بك وقم بتكوين `PrintRequestAttributeSet` و `RenderingOptions` وفقًا لمتطلبات الطباعة الخاصة بك.

{{% alert color="primary" %}} 
يرجى ملاحظة أن طباعة الملاحظات يجب أن تتطلب تغيير اتجاه الصفحة إلى `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

إذا واجهت أي مشكلات أو كنت بحاجة إلى المزيد من المساعدة، لا تتردد في التواصل مع [فريق الدعم الخاص بنا](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // تعريف اسم الطابعة
    String printerName = "Adobe PDF";
    // تعريف الشرائح للطباعة
    int[] slidesToPrint = { 2, 3, 4 };
    // تعريف اتجاه الصفحة
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // تعريف عامل المقياس لعرض الصور
    final int scaleFactor = 4;

    // تعيين سمات الطباعة
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // تكوين خيارات العرض للشرائح
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // لطباعة الملاحظات، استخدم OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // تحميل ملف العرض التقديمي
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // الحصول على وظيفة الطابعة
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // تعيين خدمة الطباعة المرغوبة
        printerJob.setPrintService(findPrintService(printerName));

        // الحصول على تنسيق الصفحة الافتراضي
        final PageFormat pageFormat = printerJob.defaultPage();

        // تعريف أبعاد الصورة بناءً على الاتجاه
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // الاتجاه الأفقي
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // الاتجاه العمودي
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // عرض صور الشرائح
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // التخلص من كائن العرض التقديمي
        pres.dispose();

        // تعيين الطباعة المتعددة الصور لوظيفة الطابعة
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // طباعة الشرائح مع السمات المحددة
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// طريقة للبحث عن خدمة الطباعة حسب اسمها
static PrintService findPrintService(String printerName)
{
    PrintService[] printServices = PrintServiceLookup.lookupPrintServices(null, null);
    for (PrintService service : printServices) {
        if (service.getName().equals(printerName)) {
            return service;
        }
    }
    return null;
}

// طريقة لتحويل مصفوفة من كائنات IImage إلى قائمة من كائنات BufferedImage
static List<BufferedImage> convertToBufferedImage(IImage[] images) throws IOException {
    List<BufferedImage> result = new ArrayList<>();
    for (IImage img : images)
    {
        final ByteArrayOutputStream baos = new ByteArrayOutputStream();
        img.save(baos, ImageFormat.Png);
        img.dispose();

        result.add(ImageIO.read(new ByteArrayInputStream(baos.toByteArray())));
    }
    return result;
}

// فصل ثابت MultiImagePrintable الذي implements واجهة Printable
static class MultiImagePrintable implements Printable
{
    private java.util.List<BufferedImage> images;

    public MultiImagePrintable(java.util.List<BufferedImage> images)
    {
        this.images = images;
    }

    @Override
    public int print(Graphics g, PageFormat pf, int pageIndex)
    {
        if (pageIndex >= images.size())
            return Printable.NO_SUCH_PAGE;

        Graphics2D g2d = (Graphics2D) g;
        g2d.translate(pf.getImageableX(), pf.getImageableY());

        Image image = images.get(pageIndex);

        double scaleX = pf.getImageableWidth() / image.getWidth(null);
        double scaleY = pf.getImageableHeight() / image.getHeight(null);
        double scale = Math.min(scaleX, scaleY);

        int width = (int) (image.getWidth(null) * scale);
        int height = (int) (image.getHeight(null) * scale);

        g.drawImage(image, 0, 0, width, height, null);

        return Printable.PAGE_EXISTS;
    }
}
```