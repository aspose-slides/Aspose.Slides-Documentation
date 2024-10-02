---
title: Печать презентации
type: docs
weight: 50
url: /ru/androidjava/print-presentation/
keywords: "Печать PowerPoint, PPT, PPTX, Печать презентации, Java, Принтер, PrinterJob, PrintService"
description: "Печать презентации PowerPoint на Java"
---

В Aspose.Slides для Android через Java 24.4 мы ввели [Современный API](https://docs.aspose.com/slides/androidjava/modern-api/), который ограничивает поддержку печати. Однако мы подошли к этому по-новому, чтобы помочь вам преодолеть это ограничение. В этой статье мы покажем вам, как напечатать презентацию, используя текущий API.

## Печать презентации

Этот фрагмент кода на Java демонстрирует, как напечатать презентацию PowerPoint, используя Aspose.Slides для Android через Java API.

Чтобы напечатать презентацию, выполните следующие шаги:

1. Создайте экземпляр `PrintRequestAttributeSet` и укажите атрибуты печати, такие как ориентация и диапазон страниц.
2. Создайте экземпляр `RenderingOptions` и укажите параметры для макета заметок слайдов.
3. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), указав файл презентации.
4. Создайте экземпляр `PrinterJob`, чтобы указать желаемый принтер.
5. Сгенерируйте массив изображений слайдов с использованием метода [getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-).
6. Установите массив `IImage` в качестве печатного для `PrinterJob`.
7. Вызовите метод `print` класса `PrinterJob`.

Не забудьте заменить **"printerName"** на имя вашего конкретного принтера и настроить `PrintRequestAttributeSet` и `RenderingOptions` в соответствии с вашими требованиями к печати.

{{% alert color="primary" %}} 
Пожалуйста, обратите внимание, что для печати заметок необходимо изменить ориентацию страницы на `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

Если вы столкнетесь с какими-либо проблемами или вам потребуется дополнительная помощь, не стесняйтесь обращаться к [нашей службе поддержки](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // Определите имя принтера
    String printerName = "Adobe PDF";
    // Определите слайды для печати
    int[] slidesToPrint = { 2, 3, 4 };
    // Определите ориентацию страницы
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // Определите коэффициент масштабирования для рендеринга изображения
    final int scaleFactor = 4;

    // Установите атрибуты печати
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // Настройте параметры рендеринга для слайдов
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // Для печати заметок используйте OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Загрузите файл презентации
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // Получите задание на печать
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // Установите желаемую службу печати
        printerJob.setPrintService(findPrintService(printerName));

        // Получите формат страницы по умолчанию
        final PageFormat pageFormat = printerJob.defaultPage();

        // Определите размеры изображения в зависимости от ориентации
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // Альбомная ориентация
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // Книжная ориентация
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // Рендеринг изображений слайдов
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // Освободите объект презентации
        pres.dispose();

        // Установите печатный объект с несколькими изображениями для задания печати
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // Напечатайте слайды с указанными атрибутами
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// Метод для поиска сервиса печати по его имени
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

// Метод для преобразования массива объектов IImage в список объектов BufferedImage
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

// Статический класс MultiImagePrintable, который реализует интерфейс Printable
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