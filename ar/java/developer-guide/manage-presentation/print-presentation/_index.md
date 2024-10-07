---
title: تقديم الطباعة
type: docs
weight: 50
url: /java/print-presentation/
keywords: "طباعة باوربوينت, PPT, PPTX, تقديم الطباعة, جافا, طابعة, PrinterJob, PrintService"
description: "طباعة تقديم باوربوينت بلغة جافا"
---

في Aspose.Slides لـ Java 24.4، قدمنا [واجهة برمجة تطبيقات حديثة](https://docs.aspose.com/slides/java/modern-api/) تقتصر على دعم الطباعة. ومع ذلك، اعتمدنا نهجًا جديدًا لمساعدتك في التغلب على هذه القيود. في هذه المقالة، سنعرض لك كيفية طباعة تقديم باستخدام واجهة البرمجة الحالية.

## تقديم الطباعة

توضح هذه الشفرة البرمجية بلغة جافا كيفية طباعة تقديم باوربوينت باستخدام واجهة برمجة تطبيقات Aspose.Slides لـ Java.

لطباعة تقديم، اتبع الخطوات التالية:

1. أنشئ مثيلًا من `PrintRequestAttributeSet` وحدد خصائص الطباعة مثل الاتجاه ونطاق الصفحات.
2. أنشئ مثيلًا من `RenderingOptions` وحدد الخيارات لتخطيط ملاحظات الشريحة.
3. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class، مع تحديد ملف التقديم.
4. أنشئ مثيلًا من `PrinterJob` لتحديد الطابعة المطلوبة.
5. قم بإنشاء مصفوفة من صور الشرائح باستخدام [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) method.
6. قم بتعيين مصفوفة `IImage` كقابلة للطباعة لـ `PrinterJob`.
7. استدعِ الطريقة `print` من فئة `PrinterJob`.

تأكد من استبدال **"printerName"** باسم الطابعة الخاصة بك وقم بتكوين `PrintRequestAttributeSet` و `RenderingOptions` وفقًا لمتطلبات الطباعة الخاصة بك.

{{% alert color="primary" %}} 
يرجى ملاحظة أن طباعة الملاحظات تتطلب تغيير اتجاه الصفحة إلى `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

إذا واجهت أي مشاكل أو كنت بحاجة إلى مزيد من المساعدة، فلا تتردد في التواصل مع [فريق الدعم](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // تعريف اسم الطابعة
    String printerName = "Adobe PDF";
    // تعريف الشرائح للطباعة
    int[] slidesToPrint = { 2, 3, 4 };
    // تعريف اتجاه الصفحة
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // تعريف عامل المقياس لتقديم الصورة
    final int scaleFactor = 4;

    // تعيين خصائص الطباعة
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // تكوين خيارات التقديم للشرائح
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // لطباعة الملاحظات، استخدم OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // تحميل ملف التقديم
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // الحصول على مهمة الطباعة
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // تعيين خدمة الطباعة المطلوبة
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
            // الاتجاه الرأسي
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // تقديم صور الشرائح
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // التخلص من كائن التقديم
        pres.dispose();

        // تعيين الطباعة المتعددة الصور لمهمة الطباعة
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // طباعة الشرائح مع الخصائص المحددة
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// طريقة للعثور على خدمة طباعة باستخدام اسمها
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

// فئة ثابتة MultiImagePrintable التي تنفذ واجهة Printable
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