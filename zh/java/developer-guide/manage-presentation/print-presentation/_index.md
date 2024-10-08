---
title: 打印演示文稿
type: docs
weight: 50
url: /zh/java/print-presentation/
keywords: "打印 PowerPoint, PPT, PPTX, 打印演示文稿, Java, 打印机, PrinterJob, PrintService"
description: "在 Java 中打印 PowerPoint 演示文稿"
---

在 Aspose.Slides for Java 24.4 中，我们引入了一个 [现代 API](https://docs.aspose.com/slides/java/modern-api/)，该 API 限制了打印支持。然而，我们采用了一种新方法来帮助您克服此限制。在本文中，我们将向您展示如何使用当前 API 打印演示文稿。

## 打印演示文稿

此 Java 代码片段演示了如何使用 Aspose.Slides for Java API 打印 PowerPoint 演示文稿。

要打印演示文稿，请按照以下步骤操作：

1. 创建 `PrintRequestAttributeSet` 的实例，并指定打印属性，例如方向和页面范围。
2. 创建 `RenderingOptions` 的实例，并指定幻灯片备注布局的选项。
3. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例，并指定演示文稿文件。
4. 创建 `PrinterJob` 的实例以指定所需的打印机。
5. 使用 [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) 方法生成幻灯片图像数组。
6. 将 `IImage` 数组设置为 `PrinterJob` 的可打印对象。
7. 调用 `PrinterJob` 类的 `print` 方法。

确保将 **"printerName"** 替换为您特定打印机的名称，并根据您的打印要求配置 `PrintRequestAttributeSet` 和 `RenderingOptions`。

{{% alert color="primary" %}} 
请注意，打印备注必须要求将页面方向更改为 `OrientationRequested.PORTRAIT`。
{{% /alert %}} 

如果您遇到任何问题或需要进一步的帮助，请随时联系 [我们的支持团队](https://forum.aspose.com/c/slides/11)。

```java
public void print() 
{
    // 定义打印机名称
    String printerName = "Adobe PDF";
    // 定义要打印的幻灯片
    int[] slidesToPrint = { 2, 3, 4 };
    // 定义页面方向
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // 定义图像渲染的缩放因子
    final int scaleFactor = 4;

    // 设置打印属性
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // 配置幻灯片的渲染选项
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // 要打印备注，请使用 OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 加载演示文稿文件
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // 获取打印作业
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // 设置所需的打印服务
        printerJob.setPrintService(findPrintService(printerName));

        // 获取默认页面格式
        final PageFormat pageFormat = printerJob.defaultPage();

        // 根据方向定义图像尺寸
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // 横向方向
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // 纵向方向
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // 渲染幻灯片图像
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // 释放演示文稿对象
        pres.dispose();

        // 为打印作业设置多图像可打印对象
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // 使用指定的属性打印幻灯片
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// 通过名称查找 PrintService 的方法
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

// 将 IImage 对象数组转换为 BufferedImage 对象列表的方法
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

// 实现 Printable 接口的静态类 MultiImagePrintable
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