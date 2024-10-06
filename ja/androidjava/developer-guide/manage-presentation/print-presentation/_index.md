---
title: プリント プレゼンテーション
type: docs
weight: 50
url: /ja/androidjava/print-presentation/
keywords: "PowerPointの印刷, PPT, PPTX, プレゼンテーションの印刷, Java, プリンター, PrinterJob, PrintService"
description: "JavaでPowerPointプレゼンテーションを印刷する"
---

Aspose.Slides for Android via Java 24.4 では、印刷サポートを制限する[モダンAPI](https://docs.aspose.com/slides/androidjava/modern-api/)を導入しました。しかし、この制限を克服するために新しいアプローチを採用しました。この記事では、現在のAPIを使用してプレゼンテーションを印刷する方法を示します。

## プレゼンテーションの印刷

このJavaコードスニペットは、Aspose.Slides for Android via Java APIを使用してPowerPointプレゼンテーションを印刷する方法を示しています。

プレゼンテーションを印刷するには、以下の手順に従ってください。

1. `PrintRequestAttributeSet` のインスタンスを作成し、印刷属性（向きやページ範囲など）を指定します。
2. `RenderingOptions` のインスタンスを作成し、スライドノートレイアウトのオプションを指定します。
3. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションファイルを指定します。
4. `PrinterJob` のインスタンスを作成し、希望するプリンターを指定します。
5. [getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) メソッドを使用してスライド画像の配列を生成します。
6. `IImage` 配列を `PrinterJob` に対して印刷可能として設定します。
7. `PrinterJob` クラスの `print` メソッドを呼び出します。

**"printerName"** を特定のプリンター名に置き換え、印刷要件に応じて `PrintRequestAttributeSet` と `RenderingOptions` を設定してください。

{{% alert color="primary" %}} 
ノートを印刷するには、ページの向きを `OrientationRequested.PORTRAIT` に変更する必要があることに注意してください。
{{% /alert %}} 

問題が発生した場合やさらなる支援が必要な場合は、[サポートチーム](https://forum.aspose.com/c/slides/11)にお問い合わせください。

```java
public void print() 
{
    // プリンター名を定義
    String printerName = "Adobe PDF";
    // 印刷するスライドを定義
    int[] slidesToPrint = { 2, 3, 4 };
    // ページの向きを定義
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // 画像描画のスケールファクターを定義
    final int scaleFactor = 4;

    // 印刷属性を設定
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // スライドの描画オプションを設定
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // ノートを印刷するには, OrientationRequested.PORTRAITを使用
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // プレゼンテーションファイルを読み込む
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // プリンタージョブを取得
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // 希望する印刷サービスを設定
        printerJob.setPrintService(findPrintService(printerName));

        // デフォルトのページ形式を取得
        final PageFormat pageFormat = printerJob.defaultPage();

        // 向きに基づいて画像の寸法を定義
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // 横向き
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // 縦向き
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // スライド画像を描画
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // プレゼンテーションオブジェクトを解放
        pres.dispose();

        // 複数画像印刷用にプリンタージョブを設定
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

// Printableインターフェイスを実装する静的クラスMultiImagePrintable
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