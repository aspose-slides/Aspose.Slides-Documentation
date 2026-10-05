---
title: Android上のプレゼンテーションでOLEを管理する
linktitle: OLEの管理
type: docs
weight: 40
url: /ja/androidjava/manage-ole/
keywords:
- OLEオブジェクト
- オブジェクトリンクと埋め込み
- OLEを追加
- OLEを埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLEを変更
- OLEアイコン
- OLEタイトル
- OLEを抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **導入**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}}

Microsoft Excel で作成したグラフを考えてみてください。そのグラフを PowerPoint のスライドに配置したものが OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション（Excel）でグラフが開くか、オブジェクトを開くまたは編集するアプリケーションの選択を求められます。
- OLE オブジェクトは実際の内容（例えばグラフ）を表示することもできます。この場合、PowerPoint 内でグラフがアクティブになり、インターフェイスが読み込まれ、PowerPoint 上でグラフのデータを変更できます。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレームとして挿入できます（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）。

## **スライドに OLE オブジェクトフレームを追加する**

Microsoft Excel でグラフを作成し、Aspose.Slides for Android via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込む場合、以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルから取得したグラフを Aspose.Slides for Android via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは第2パラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLEオブジェクトのデータを準備します。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// スライドにOLEオブジェクトフレームを追加します。
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **リンクされた OLE オブジェクトフレームの追加**

Aspose.Slides for Android via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) を追加できます。

この Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされたExcelファイルを使用してOLEオブジェクトフレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクトフレームへのアクセス**

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順で簡単に見つけてアクセスできます。

1. 埋め込み OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドへの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。  
   本例では、最初のスライドに 1 つだけシェイプがある以前に作成した PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) として *cast* しました。これがアクセス対象の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel グラフオブジェクト）とそのファイルデータにアクセスしています。

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込みファイルデータを取得します。
    // 埋め込みファイルの拡張子を取得します。
    // ...
}
```

### **リンクされた OLE オブジェクトフレームのプロパティにアクセスする**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

この Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLEオブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのはPPTプレゼンテーションだけです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE オブジェクトデータの変更**

{{% alert color="info" title="Note" %}}

このセクションのコード例は、[Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/) を使用しています。

{{% /alert %}}

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でそのオブジェクトにアクセスし、データを変更できます。

1. 埋め込み OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドへの参照を取得します。 
3. OLE オブジェクトフレーム シェイプにアクセスします。  
   本例では、最初のスライドに 1 つのシェイプがある以前に作成した PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) として *cast* しました。これがアクセス対象の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスし、データを修正します。
7. 更新した `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクトデータを変更します。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel グラフオブジェクト）にアクセスし、ファイルデータを変更してグラフデータを更新しています。

```java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLEオブジェクトデータをWorkbookオブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbookのデータを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLEフレームオブジェクトのデータを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **スライドに他のファイルタイプを埋め込む**

Excel グラフ以外にも、Aspose.Slides for Android via Java を使用すると、HTML、PDF、ZIP などのさまざまなファイルタイプをスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を求められます。

この Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みオブジェクトのファイルタイプを設定する**

プレゼンテーション作業中に、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要がある場合があります。Aspose.Slides for Android via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームデータまたは拡張子を更新できます。

この Java コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みオブジェクトのアイコン画像とタイトルを設定する**

OLE オブジェクトを埋め込むと、プレビューとしてアイコン画像が自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Android via Java を使用してアイコン画像とタイトルを設定できます。

この Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクトフレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを取得しプレビューを更新するため、OLE オブジェクトフレームのサイズや位置が変わることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) インターフェイスの [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) メソッドに `false` を渡して呼び出します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **埋め込みファイルの抽出**

Aspose.Slides for Android via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLE オブジェクトフレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

この Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**スライドを PDF/画像にエクスポートしたとき、OLE コンテンツはレンダリングされますか？**

スライド上に表示されるのはアイコン／代替画像（プレビュー）です。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待通りに表示されるよう独自のプレビュー画像を設定してください。

埋め込みファイルを PDF 添付ファイルとしても保持したい場合は、[setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) に `true` を指定します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順については、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動／編集できないようにするには？**

シェイプレベルでロックを設定します。Aspose.Slides はシェイプロック機能を提供します。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。

**リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint がリンクされた OLE のプレビューを再生成するためです。安定した表示を得るには、[Working Solution for Worksheet Resizing](/slides/ja/androidjava/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を考慮する場合は、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを検討してください。

{{...}}