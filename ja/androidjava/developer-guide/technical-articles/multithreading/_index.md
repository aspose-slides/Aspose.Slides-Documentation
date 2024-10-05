---
title: Aspose.Slidesにおけるマルチスレッド
type: docs
weight: 310
url: /androidjava/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並行作業
- スライドを変換
- スライドから画像へ
- Android
- Java
- Java経由のAspose.Slides for Android
---

## **はじめに**

プレゼンテーションを使った並行作業は可能ですが（解析/読み込み/クローン作成を除く）、多くの場合うまくいく一方で、ライブラリを複数のスレッドで使用すると、誤った結果が得られる可能性がわずかにあります。

複数スレッドの環境で単一の[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)インスタンスを使用することは**推奨しません**。これは、予測できないエラーや、簡単には検出できない失敗の原因となる可能性があります。

複数スレッドで[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを読み込んだり、保存したり、クローン作成したりすることは**安全ではありません**。そのような操作は**サポートされていません**。もしそのような作業を行う必要がある場合は、複数の単一スレッドプロセスを使用して操作を並行させる必要があり、各プロセスは自身のプレゼンテーションインスタンスを使用するべきです。

## **プレゼンテーションスライドを並行して画像に変換する**

例えば、PowerPointプレゼンテーションのすべてのスライドをPNG画像に並行して変換したいとします。複数スレッドで単一の`Presentation`インスタンスを使用することが安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各プレゼンテーションを別々のスレッドで使用してスライドを画像に並行して変換します。以下のコード例は、その方法を示しています。

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// スライドiを別のプレゼンテーションとして抽出します。
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// 別のタスクでスライドを画像に変換します。
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// すべてのタスクが完了するまで待ちます。
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```