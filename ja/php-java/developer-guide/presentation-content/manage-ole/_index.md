---
title: PHP を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/php-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、Microsoft の技術で、あるアプリケーションで作成されたデータやオブジェクトをリンクまたは埋め込みにより別のアプリケーションに配置できるようにします。 

{{% /alert %}} 

たとえば、Microsoft Excel で作成したグラフを PowerPoint のスライドに配置したとします。この Excel のグラフは OLE オブジェクトとして扱われます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション（Excel）でグラフが開くか、オブジェクトを開く／編集するアプリケーションの選択を求められます。 
- OLE オブジェクトは実際のコンテンツ（たとえばグラフの内容）を表示することもあります。この場合、PowerPoint 上でグラフがアクティブになり、インターフェイスが読み込まれ、PowerPoint 内でグラフのデータを編集できます。 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）として挿入できます。 

## **スライドに OLE オブジェクト フレームを追加する**

既に Microsoft Excel で作成したチャートを Aspose.Slides for PHP via Java を使って OLE オブジェクト フレームとしてスライドに埋め込む手順は次のとおりです。 

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. Excel ファイルをバイト配列として読み取ります。  
1. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) をスライドに追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for PHP via Java を使用して OLE オブジェクト フレームとしてスライドに追加しています。  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) コンストラクタは、埋め込み可能オブジェクトの拡張子を第 2 パラメータとして受け取ります。この拡張子により、PowerPoint がファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。  
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


### **リンクされた OLE オブジェクト フレームを追加する**

Aspose.Slides for PHP via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) を追加できます。  

以下の PHP コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) をスライドに追加する方法を示しています：  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **OLE オブジェクト フレームにアクセスする**

スライドに既に埋め込まれている OLE オブジェクトがある場合、次の手順で簡単に見つけたりアクセスしたりできます。  

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込む。  
2. インデックスを使用してスライドの参照を取得する。  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスする。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用しています。  
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を行うことができます。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel のチャート オブジェクト）とそのファイルデータにアクセスしています。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 埋め込まれたファイルデータを取得します。
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **リンクされた OLE オブジェクト フレームのプロパティにアクセスする**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。  

以下の PHP コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
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


## **OLE オブジェクト データを変更する**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for PHP via Java](/cells/php-java/) を使用しています。 

{{% /alert %}}  

スライドに既に埋め込まれている OLE オブジェクトがある場合、次の手順でオブジェクトにアクセスし、データを変更できます。  

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込む。  
2. インデックスを使用してスライドの参照を取得する。  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスする。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用しています。  
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を行うことができます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスする。  
6. 目的の `Worksheet` にアクセスし、データを修正する。  
7. 更新した `Workbook` をストリームに保存する。  
8. ストリームから OLE オブジェクト データを変更する。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel のチャート オブジェクト）にアクセスし、ファイルデータを変更してチャート データを更新しています。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

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


## **スライドに他のファイルタイプを埋め込む**

Excel のチャートに加えて、Aspose.Slides for PHP via Java を使用すると、HTML、PDF、ZIP などの他の種類のファイルをスライドにオブジェクトとして埋め込むことができます。ユーザーが埋め込まれたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、開くプログラムの選択を求められます。  

以下の PHP コードは、HTML と ZIP をスライドに埋め込む方法を示しています：  
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


## **埋め込みオブジェクトのファイルタイプを設定する**

プレゼンテーションで作業していると、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要が生じることがあります。Aspose.Slides for PHP via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。  

以下の PHP コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：  
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


## **埋め込みオブジェクトのアイコン画像とタイトルを設定する**

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューはユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for PHP via Java を使用してアイコン画像とタイトルを設定できます。  

以下の PHP コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// プレゼンテーションリソースに画像を追加します。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// OLE プレビュー用にタイトルと画像を設定します。
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **OLE オブジェクト フレームのサイズ変更と位置変更を防止する**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新し、プレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を求めないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) クラスの `setUpdateAutomatic` メソッドを `false` に設定します：  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **埋め込みファイルを抽出する**

Aspose.Slides for PHP via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。  

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成する。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスする。  
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出す。  

以下の PHP コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：  
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

**OLE コンテンツはスライドを PDF／画像にエクスポートするときにレンダリングされますか？**  

スライド上に表示されるもの（アイコン／代替画像（プレビュー））がレンダリングされます。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待通りの外観になるようプレビュー画像を設定してください。  

**PowerPoint でユーザーが OLE オブジェクトを移動／編集できないようにロックするにはどうすればよいですか？**  

シェイプをロックします。Aspose.Slides はシェイプレベルのロック機能を提供します。これは暗号化ではありませんが、誤操作や移動を実質的に防止します。  

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**  

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧式の PPT 形式で使用されます。可搬性を考える場合は、信頼できる絶対パス／アクセス可能な URI もしくは埋め込みを推奨します。