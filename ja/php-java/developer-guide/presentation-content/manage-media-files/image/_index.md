---
title: "PHP を使用したプレゼンテーションにおける画像管理の最適化"
linktitle: "画像の管理"
type: docs
weight: 10
url: /ja/php-java/image/
keywords:
- "画像を追加"
- "画像を追加"
- "画像を置換"
- "画像コレクション"
- "画像フレーム"
- "リンク画像"
- "背景"
- "PNG を追加"
- "JPG を追加"
- "SVG を追加"
- "SVG をシェイプに変換"
- "外部 SVG リソース"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで、ラスタ画像と SVG 画像の追加、再利用、リンク、置換、管理方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java には画像を操作するためのさまざまな方法があり、それぞれ目的が異なります。画像をプレゼンテーションに埋め込んだり、画像フレームに表示したり、スライドの背景として使用したり、外部画像へのリンクを設定したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

この記事では画像リソースとプレゼンテーション全体での使用方法に焦点を当てます。個々の画像フレームに対して行う切り抜き、透明度、エフェクト、伸縮、その他の書式設定については、[Picture Frame](/slides/ja/php-java/picture-frame/) を参照してください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、互換性はありません。

- [プレゼンテーション画像コレクション]((https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/)) はプレゼンテーションで使用される画像リソースを格納します。`ImageCollection::addImage` を使用して画像データを追加し、`PPImage` リソースを取得します。
- [画像フレーム]((https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/)) はスライド、レイアウト、またはマスター上に画像を表示するシェイプです。`ShapeCollection::addPictureFrame` を使用して画像リソースをスライドに配置します。
- スライド背景はシェイプとしてではなく、スライドの塗りつぶしの一部として画像を使用します。そのため画像フレームとは振る舞いが異なります。
- `PPImage::replaceImage` は画像リソースを置き換えます。そのリソースを使用しているすべてのプレゼンテーション要素が置き換え後の画像を使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後はコンテンツは単一の画像リソースとして管理されなくなります。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、`PPImage` を取得し、取得したリソースを1つまたは複数の画像フレームや塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み込み、画像コレクションに追加し、返された `PPImage` を使用する画像フレームを作成します。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、結果として得られるファイルは元の画像ファイルが利用できなくても問題ありません。

### **Web から画像を追加**

画像が HTTP または HTTPS 経由で取得可能な場合、バイト列をダウンロードし、プレゼンテーション画像コレクションに追加し、ローカル画像と同様に返された画像リソースを使用します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

長時間実行するアプリケーションでは、不要なネットワークインフラを毎回作成するのではなく、適切な HTTP クライアントや接続管理戦略を再利用してください。また、信頼できないソースの場合はリモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用する**

同じ画像を複数回使用する必要がある場合は、プレゼンテーションに一度だけ画像を追加し、追加の画像フレームを作成するときに取得した `PPImage` を再利用します。これにより同じソースデータの読み込みが繰り返されず、共有画像リソースとその使用箇所の関係が明示的になります。

多くのスライドに自動的に表示させたいロゴなどのグラフィックは、各スライドに同等のシェイプを追加する代わりに、[スライドマスター](/slides/ja/php-java/slide-master/) またはレイアウト上に画像フレームを配置することを検討してください。

## **画像をスライド背景として使用する**

背景画像はスライドの塗りつぶしに割り当てられ、画像フレームのシェイプとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されない場合に便利です。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

マスターやレイアウトの背景を含む追加の背景オプションについては、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像では可搬性とファイルサイズに異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。自己完結型ですが、ファイルサイズに画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。プレゼンテーションのサイズは小さくなりますが、開くまたはレンダーする際に外部リソースにアクセスできる必要があります。

外部パスまたは URL を `[Picture::setLinkPathLong]((https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/))` で設定することで、画像データを埋め込まずにリンク画像を作成できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

外部リソースに確実にアクセスできる環境でのみリンク画像を使用してください。オフラインで使用する、またはシステム間で移動させる必要があるプレゼンテーションでは、埋め込み画像の方が安全です。

## **SVG 画像の取り扱い**

SVG はベクターフォーマットであるため、アイコンや図表など、ラスター画像と比べて詳細を失わずに拡大縮小できるグラフィックに適しています。Aspose.Slides は SVG を画像リソースとして、また編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

`SvgImage` を作成し、画像コレクションに追加し、得られた画像リソースを画像フレームに配置します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **外部リソースを持つ SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できます。このような場合、`SvgImage` は `ExternalResourceResolver` とベース URI を受け取るコンストラクタを提供します。リゾルバーは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返します。

リゾルバーは SVG 処理中に外部リソースへのアクセスを可能にしますが、SVG を自己完結型ドキュメントに書き換えることはありません。SVG を可搬に保つ必要がある場合は、リンク画像に対して `data:` URI を使用するなどして、必要なリソースを SVG 内に埋め込んでください。

信頼できないソースからの SVG ファイルを処理する場合は、リゾルバーがアクセスできるスキーム、ファイル場所、ホストを制限し、ネットワークリゾルバーにはタイムアウト、レスポンスサイズ上限、コンテンツ検証を適用してください。

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換できます。これは PowerPoint の対応コマンドと同等です。

![PowerPoint Popup Menu](img_01_01.png)

`ShapeCollection::addGroupShape` のオーバーロードで `SvgImage` を受け取るものを使用して変換を実行します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

個々のベクター要素を PowerPoint のシェイプとして編集する必要がある場合に SVG→シェイプ変換を使用してください。表示だけが目的であれば、画像として保持した方がシンプルで、多数のシェイプを生成する手間を省けます。

## **既存画像リソースの置換**

`PPImage::replaceImage` を使用すると、既存の画像リソースを置き換えることができます。ロゴなどの共有グラフィックを置換する際に特に便利です。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

同じ画像リソースを使用している複数の画像フレーム、背景、マスター、レイアウトがある場合、リソースを置換するとそれらすべてが更新されます。1つの画像フレームだけを変更したい場合は、共有リソースを置換せずに別の画像をそのフレームに割り当ててください。

`PPImage::replaceImage` にはバイト配列や別の `PPImage` を受け取るオーバーロードも用意されています。

## **実践的な画像管理ガイドライン**

### **プレゼンテーションサイズの制御**

大きなラスター画像はプレゼンテーションを不必要に肥大化させます。表示サイズに見合った解像度の画像を使用し、可能な限り共有画像リソースを再利用し、同一の高解像度画像を埋め込むのは避けてください。

すでに画像フレームに配置されたラスター画像については、`PictureFillFormat::compressImage` を使用して選択した解像度とトリミング設定に基づき画像データを圧縮できます。これは画像フレームの処理であり、画像コレクションの管理とは別です。関連する書式設定操作については [Picture Frame](/slides/ja/php-java/picture-frame/) を参照してください。

### **埋め込みとリンクコンテンツの選択**

埋め込みはすべての画像データがファイルに同梱されるため、プレゼンテーションの可搬性が高まります。リンクはファイルサイズを削減できますが、外部依存が発生します。外部依存が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴや透かし、装飾グラフィックが多数スライドで使用される場合は、1つの画像リソースを作成して再利用します。スライドコンテンツではなくプレゼンテーションのデザインに属するグラフィックは、マスターまたはレイアウトに配置して適切なスライドに継承させてください。

### **SVG リソースの可搬性保持**

自己完結型の SVG は外部ファイルやネットワークリソースに依存する SVG よりも移動やレンダーが容易です。可能な限り必要なリソースを埋め込んでから SVG をインポートしてください。個々のベクター要素の編集が必要な場合にのみ、SVG をシェイプに変換します。

### **最新のクロスプラットフォーム画像 API の使用**

新規の PHP via Java コードでは、レガシーの `java.awt.image.BufferedImage` ベースの公開 API ではなく、Aspose.Slides の `IImage` および `Images` API を使用してください。移行手順は [Modern API](/slides/ja/php-java/modern-api/) を参照してください。

WMF および EMF は特別な取り扱いが必要です。これらの形式が `IImage` を通して処理される場合、`ImageCollection::addImage` はメタファイルをラスタ PNG に変換して挿入します。メタファイルデータを保持したい場合は、ストリームベースの `ImageCollection::addImage` オーバーロードを使用してください。スプレッドシート等から EMF コンテンツを生成するフローは別途統合作業が必要であり、本記事の範囲外です。

## **FAQ**

**画像コレクションと画像フレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを保存します。画像フレームはそのリソースの一つを表示するスライドシェイプで、切り抜きやエフェクトといった画像固有の書式設定を提供します。

**ロゴを全スライドで同じように置き換えるベストな方法は？**

ロゴがすでに 1 つの画像リソースとして共有されている場合は、`PPImage::replaceImage` でそのリソースを置換します。プレゼンテーション全体のブランディングとしては、ロゴをマスターまたはレイアウトに配置すると、スライドごとの重複を減らせます。

**リンク画像が別のコンピュータで消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。そのリソースに別のコンピュータからアクセスできない場合、リンク画像は表示できなくなります。自己完結型が必要な場合は画像を埋め込んでください。

**挿入した SVG は PowerPoint のシェイプとして編集できますか？**

はい。`ShapeCollection::addGroupShape` を使って SVG を変換すれば、生成されたグループは SVG 画像ではなく編集可能なスライドシェイプを含みます。

**画像が多数あるプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不必要に大きなラスターソースを避け、適切な場合は画像圧縮を行い、繰り返し使用するブランディングはマスターやレイアウトに置き、外部依存が許容できる場合にのみリンク画像を使用してください。