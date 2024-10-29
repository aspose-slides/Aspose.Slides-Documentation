---
title: 印刷プレゼンテーション
type: docs
weight: 50
url: /ja/java/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, Java, Printer, PrinterJob, PrintService"
description: "JavaでPowerPointプレゼンテーションを印刷する"
---

Aspose.Slides for Java 24.4 では、印刷サポートを制限する[モダンAPI](https://docs.aspose.com/slides/java/modern-api/)を導入しました。ただし、この制限を克服するための新しいアプローチを採用しました。この記事では、現在のAPIを使用してプレゼンテーションを印刷する方法を説明します。

## 印刷プレゼンテーション

このJavaコードスニペットは、Aspose.Slides for Java APIを使用してPowerPointプレゼンテーションを印刷する方法を示しています。

プレゼンテーションを印刷するには、次の手順に従います：

1. `PrintRequestAttributeSet` のインスタンスを作成し、印刷属性（方向やページ範囲など）を指定します。
2. `RenderingOptions` のインスタンスを作成し、スライドノートのレイアウトオプションを指定します。
3. プレゼンテーションファイルを指定して、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
4. 希望のプリンターを指定するために `PrinterJob` のインスタンスを作成します。
5. [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) メソッドを使用してスライド画像の配列を生成します。
6. `IImage` 配列を `PrinterJob` 用の印刷可能なオブジェクトとして設定します。
7. `PrinterJob` クラスの `print` メソッドを呼び出します。

**"printerName"** を特定のプリンターの名前に置き換え、印刷要件に応じて `PrintRequestAttributeSet` と `RenderingOptions` を設定してください。

{{% alert color="primary" %}} 
ノートを印刷する場合は、ページの方向を `OrientationRequested.PORTRAIT` に変更する必要がありますのでご注意ください。
{{% /alert %}} 

問題が発生した場合や追加の支援が必要な場合は、[サポートチーム](https://forum.aspose.com/c/slides/11)にお気軽にお問い合わせください。

```java
public void print() 
{
    // プリンターの名前を定義
    String printerName = "Adobe PDF";
    // 印刷するスライドを定義
    int[] slidesToPrint = { 2, 3, 4 };
    // ページの方向を定義
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // 画像レンダリングのスケールファクターを定義
    final int scaleFactor = 4;

    // 印刷属性を設定
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // スライド用のレンダリングオプションを設定
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // ノートを印刷するには、OrientationRequested.PORTRAITを使用
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // プレゼンテーションファイルをロード
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // プリンタージョブを取得
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // 希望の印刷サービスを設定
        printerJob.setPrintService(findPrintService(printerName));

        // デフォルトのページフォーマットを取得
        final PageFormat pageFormat = printerJob.defaultPage();

        // 方向に基づいて画像の寸法を定義
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // 横方向
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // 縦方向
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // スライドの画像をレンダリング
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // プレゼンテーションオブジェクトを処理
        pres.dispose();

        // マルチイメージを印刷可能に設定
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // 指定された属性でスライドを印刷
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// 名前でPrintServiceを見つけるメソッド
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

// IImageオブジェクトの配列をBufferedImageオブジェクトのリストに変換するメソッド
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

// Printableインターフェースを実装する静的クラスMultiImagePrintable
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