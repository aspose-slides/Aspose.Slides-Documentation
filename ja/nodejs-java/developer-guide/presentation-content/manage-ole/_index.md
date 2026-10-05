---
title: JavaScript を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **はじめに**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。 
{{% /alert %}} 

MS Excelで作成したチャートを考えてみてください。そのチャートが PowerPoint のスライドに配置されます。その Excel チャートは OLE オブジェクトと見なされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション (Excel) でチャートが開くか、オブジェクトを開く／編集するアプリケーションの選択を求められます。  
- OLE オブジェクトは実際の内容（例：チャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートが有効化され、チャート インターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。  

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクト フレームとして挿入できます ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame))。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Node.js via Java を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順で行えます：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Node.js via Java を使用して OLE オブジェクト フレームとしてスライドに追加しています。  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for Node.js via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) を追加できます。

この JavaScript コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています：

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に見つけたりアクセスしたりできます：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、最初のスライドに1つだけシェイプがある事前に作成した PPTX を使用しました。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  

以下の例では、スライドに埋め込まれた Excel チャート オブジェクトの OLE オブジェクト フレームとそのファイル データにアクセスしています。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 埋め込まれたファイル データを取得します。
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **リンクされた OLE オブジェクト フレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

この JavaScript コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスが含まれるのは PPT プレゼンテーションだけです。
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE オブジェクト データの変更**

{{% alert color="info" title="Note" %}}
このセクションでは、以下のコード例で [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) を使用しています。  
{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でそのオブジェクトにアクセスし、データを変更できます：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. OLE オブジェクト フレーム シェイプにアクセスします。例では、最初のスライドに1つだけシェイプがある事前に作成した PPTX を使用しました。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 必要な `Worksheet` にアクセスしてデータを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクト データを変更します。  

以下の例では、スライドに埋め込まれた Excel チャート オブジェクトの OLE オブジェクト フレームにアクセスし、ファイル データを変更してチャート データを更新しています。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // ワークブック データを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **スライドへの他のファイルタイプの埋め込み**

Excel チャートに加えて、Aspose.Slides for Node.js via Java を使用すると、HTML、PDF、ZIP などの他のファイルタイプもオブジェクトとしてスライドに埋め込めます。ユーザーが挿入したオブジェクトをダブルクリックすると、関連するプログラムで自動的に開くか、適切なプログラムを選択するように求められます。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要があることがあります。Aspose.Slides for Node.js via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレーム データや拡張子を更新できます。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// ファイルタイプを ZIP に変更します。
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for Node.js via Java を使用してアイコン画像とタイトルを設定できます。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームのサイズ変更と位置変更の防止**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」を求めるメッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新しプレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変更される可能性があります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、`false` を指定して [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) クラスの [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) メソッドを呼び出します：

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みファイルの抽出**

Aspose.Slides for Node.js via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます：

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプを走査し、[OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータを取得し、ディスクに書き出します。  

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **よくある質問**

**Will the OLE content be rendered when exporting slides to PDF/images?**  
スライド上に表示されているもの（アイコン/代替画像）がレンダリングされます。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるようプレビュー画像を設定してください。  

埋め込みファイルを PDF の添付ファイルとして保持したい場合は、`true` を指定して [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) を呼び出します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順については、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。  

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
シェイプレベルのロックを使用します。Aspose.Slides はシェイプ単位でロックを提供し、暗号化ではありませんが、誤操作や移動を効果的に防止できます。  

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
PPTX では「相対パス」情報は保持されず、フルパスのみが記録されます。相対パスは旧形式の PPT にのみ存在します。可搬性を考慮する場合は、信頼できる絶対パスまたはアクセス可能な URI、あるいは埋め込みを使用してください。