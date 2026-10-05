---
title: PHP を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/php-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクトのリンクと埋め込み
- OLE の追加
- OLE の埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの追加
- ファイルの埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE の変更
- OLE アイコン
- OLE タイトル
- OLE の抽出
- オブジェクトの抽出
- ファイルの抽出
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint および OpenDocument ファイルにおける OLE オブジェクト管理を Aspose.Slides for PHP via Java で最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **イントロダクション**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

MS Excel で作成したチャートを考えてみましょう。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートが関連付けられたアプリケーション（Excel）で開くか、オブジェクトを開く・編集するアプリケーションの選択を求められます。
- OLE オブジェクトはチャートの内容など実際のコンテンツを表示することもあります。この場合、PowerPoint でチャートがアクティブになり、インターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドへのOLEオブジェクトフレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for PHP via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合、以下の手順で行えます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを指定してスライドの参照を取得します。  
1. Excel ファイルをバイト配列として読み取ります。  
1. バイト配列と OLE オブジェクトに関するその他情報を含む [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) をスライドに追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for PHP via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**注** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) コンストラクタは、埋め込むオブジェクトの拡張子を第2パラメータとして受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **リンクされたOLEオブジェクトフレームの追加**

Aspose.Slides for PHP via Java は、データを埋め込まずにファイルへのリンクのみで [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) を追加できます。

この PHP コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) をスライドに追加する方法を示しています。

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLEオブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に見つけたりアクセスしたりできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、1枚目のスライドに 1 つだけシェイプが存在する PPTX を使用しています。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel のチャートオブジェクト）とそのファイルデータにアクセスしています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 埋め込みファイルデータを取得します。
    // 埋め込まれたファイルの拡張子を取得します。
    // ...
}
```

### **リンクされたOLEオブジェクトフレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

この PHP コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルのパスを取得する方法を示しています。

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // リンクされたファイルへのフルパスを出力します。
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションのみです。
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLEオブジェクトデータの変更**

{{% alert color="info" title="Note" %}}

このセクションのコード例は、[Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/) を使用しています。

{{% /alert %}}

スライドに埋め込まれた OLE オブジェクトが既に存在する場合、次の手順でそのオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを通じてスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、1枚目のスライドに 1 つだけシェイプがある PPTX を使用しています。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 対象の `Worksheet` にアクセスし、データを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクトデータを変更します。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel のチャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新しています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Workbook のデータを変更します。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE フレーム オブジェクトのデータを変更します。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **スライドへの他のファイルタイプの埋め込み**

Excel チャートに加えて、Aspose.Slides for PHP via Java は HTML、PDF、ZIP などのさまざまなファイルタイプをスライドに埋め込むことができます。ユーザーが埋め込まれたオブジェクトをダブルクリックすると、該当プログラムで自動的に開くか、適切なプログラムの選択を促すダイアログが表示されます。

この PHP コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションで作業する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換える必要がある場合があります。Aspose.Slides for PHP via Java は、埋め込みオブジェクトのファイルタイプを設定できるため、OLE フレームのデータや拡張子を更新できます。

この PHP コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// ファイルタイプを ZIP に変更します。
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for PHP via Java を使用してアイコン画像とタイトルを設定できます。

この PHP コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// プレゼンテーションリソースに画像を追加します。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLEオブジェクトフレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」を求めるメッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新し、オブジェクトのプレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) クラスの [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) メソッドに `false` を渡して呼び出します。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **埋め込みファイルの抽出**

Aspose.Slides for PHP via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 埋め込まれた OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
3. OLE オブジェクトフレームから埋め込みファイルのデータを取得し、ディスクに書き出します。

この PHP コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**スライドを PDF/画像にエクスポートしたときに OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの（アイコン/代替画像＝プレビュー）がレンダリングされます。実際の「ライブ」OLE コンテンツはレンダリング時には実行されません。必要に応じて、エクスポートされた PDF で期待通りに表示されるよう独自のプレビュー画像を設定してください。

埋め込みファイルを PDF 添付ファイルとして保持したい場合は、[setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) に `true` を指定して呼び出します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順は、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動・編集できないようにするには？**

シェイプをロックします。Aspose.Slides はシェイプ単位のロック機能を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を効果的に防止します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」の情報は保持されません。フルパスのみが保存されます。相対パスは旧形式の PPT に存在します。移植性を確保するには、信頼できる絶対パスまたはアクセス可能な URI、あるいは埋め込みを使用することを推奨します。