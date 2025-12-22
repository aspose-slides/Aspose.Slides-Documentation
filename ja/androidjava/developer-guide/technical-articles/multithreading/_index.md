---
title: Android 用 Java による Aspose.Slides のマルチスレッド処理
linktitle: マルチスレッド処理
type: docs
weight: 310
url: /ja/androidjava/multithreading/
keywords:
- マルチスレッド
- 複数スレッド
- 並列処理
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java のマルチスレッド処理は PowerPoint と OpenDocument の処理を高速化します。効率的なプレゼンテーションワークフローのベストプラクティスをご確認ください。"
---

## **導入**

プレゼンテーションを用いた並列処理は（解析/ロード/クローンを除き）可能で、ほとんどの場合問題なく動作しますが、ライブラリを複数のスレッドで使用すると、結果が正しくないことが発生する可能性があります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)インスタンスを **使用しない** ことを強く推奨します。これにより、予測できないエラーや検出が困難な障害が発生する可能性があります。

[Presentation] クラスのインスタンスを複数のスレッドでロード、保存、またはクローンすることは **安全ではない** です。このような操作は **サポートされていません**。このようなタスクが必要な場合は、複数のシングルスレッドプロセスを使用して操作を並列化し、各プロセスがそれぞれ独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーション スライドを並列に画像へ変換**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。単一の `Presentation` インスタンスを複数のスレッドで使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドで個別のプレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例はその方法を示しています。
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
	// スライド i を別々のプレゼンテーションに抽出します。
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// スライドを別タスクで画像に変換します。
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

// すべてのタスクが完了するのを待ちます。
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```


## **よくある質問**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始される前に、プロセスまたはアプリドメイン単位で1回実行すれば十分です。[license setup](/slides/ja/androidjava/licensing/) が同時に呼び出される可能性がある場合（例: 遅延初期化時）、その呼び出しを同期させてください。license setup メソッド自体はスレッドセーフではありません。

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**

スレッド間で「ライブ」なプレゼンテーションオブジェクトを渡すことは推奨されません。各スレッドごとに独立したインスタンスを使用するか、各スレッド用に事前に別々のプレゼンテーション/スライド コンテナを作成してください。この方法は、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿ったものです。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像などの異なる形式へのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、通常このようなタスクは正しく並列化できます。共有のプレゼンテーションオブジェクトや共有 I/O ストリームは使用しないでください。

**マルチスレッド環境でのグローバルフォント設定（フォルダー、置換など）はどう扱うべきですか？**

スレッドを開始する前にすべてのグローバル [font settings](/slides/ja/androidjava/powerpoint-fonts/) を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合が解消されます。