---
title: Android でプレゼンテーションの OLE を管理する
linktitle: OLE を管理
type: docs
weight: 40
url: /ja/androidjava/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキングと埋め込み
- OLE を追加
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java で Aspose.Slides を使用し、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツの埋め込み、更新、エクスポートをシームレスに行えます。"
---
## **イントロダクション**

{{% alert color="info" %}} 

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みを通じて別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

MS Excel で作成したチャートを考えてみましょう。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトとみなされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートが関連付けられたアプリケーション（Excel）で開くか、オブジェクトの開閉や編集に使用するアプリケーションの選択を求められます。 
- OLE オブジェクトは実際の内容（たとえばチャートの内容）を表示することもあります。この場合、チャートは PowerPoint でアクティブ化され、チャートのインターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/ja/androidjava/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleObjectFrame)）として挿入できます。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Android via Java を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. バイト配列および OLE オブジェクトに関するその他の情報を含めて、スライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleObjectFrame) を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Android via Java を使用して OLE オブジェクト フレームとしてスライドに追加しています。  
**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは、2 番目のパラメータとして埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、OLE オブジェクトを開く適切なアプリケーションを選択できます。

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

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for Android via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleObjectFrame) を追加できます。

この Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. 埋め込み OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成した PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/) にキャストします。これがアクセス対象の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel チャート オブジェクト）とそのファイル データにアクセスしています。

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込まれたファイルデータを取得します。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **リンクされた OLE オブジェクト フレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

この Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE オブジェクト データの変更**

{{% alert color="info" %}} 

このセクションのコード例は、[Aspose.Cells for Android via Java](/cells/androidjava/) を使用しています。 

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスし、そのデータを変更できます。

1. 埋め込み OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。 
3. OLE オブジェクト フレーム シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成した PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/) にキャストします。これがアクセス対象の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスしてデータを変更します。
7. 更新された `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel チャート オブジェクト）にアクセスし、ファイル データを変更してチャート データを更新しています。

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

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // ワークブック データを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **スライドへの他のファイル種別の埋め込み**

Excel チャート以外にも、Aspose.Slides for Android via Java を使用すると、HTML、PDF、ZIP などのファイルをオブジェクトとしてスライドに埋め込めます。ユーザーが挿入されたオブジェクトをダブルクリックすると、自動的に関連プログラムで開くか、適切なプログラムを選択するよう求められます。

この Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています：

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

## **埋め込みオブジェクトのファイル種別の設定**

プレゼンテーションで作業する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換える必要があることがあります。Aspose.Slides for Android via Java を使用すると、埋め込みオブジェクトのファイル種別を設定でき、OLE フレームのデータまたは拡張子を更新できます。

この Java コードは、埋め込み OLE オブジェクトのファイル種別を `zip` に設定する方法を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// ファイルの種類を ZIP に変更します。
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、プレビューとしてアイコン画像が自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Android via Java を使用してアイコン画像とタイトルを設定できます。

この Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

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

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームのサイズ変更と位置変更の防止**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新しプレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変わることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します：

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

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプを走査し、[OLEObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

この Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：

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

### スライドを PDF/画像にエクスポートする際、OLE コンテンツはレンダリングされますか？

スライド上に表示されているものがレンダリングされます（アイコン/代替画像＝プレビュー）。「ライブ」な OLE コンテンツはレンダリング中に実行されません。必要に応じて、エクスポートされた PDF で期待通りに見えるように独自のプレビュー画像を設定してください。

### PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするには？

シェイプをロックします。Aspose.Slides はシェイプレベルのロック機能を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。

### リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？

PowerPoint がリンクされた OLE のプレビューを再描画するためです。安定した表示を保つには、[Worksheet Resizing の実装例](/slides/ja/androidjava/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームに合わせて代替画像を適切に設定してください。

### PPTX 形式でリンクされた OLE オブジェクトの相対パスは保持されますか？

PPTX では「相対パス」情報は保存されず、フルパスのみが保持されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を確保するには、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを検討してください。