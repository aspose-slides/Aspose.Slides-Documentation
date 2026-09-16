---
title: Java でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/java/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint および OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保つ高速な Office 不要のソリューション。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な紹介、既定設定でプレゼンテーションを XAML に保存する方法、[XamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/) を使用したエクスポートのカスタマイズ（非表示スライドのエクスポートを含む）を示します。また、フォールバックフォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも答えています。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

XAML ファイルはビジュアルデザイナーで操作したり、マークアップを直接記述・編集したりできます。

## **既定オプションでプレゼンテーションを XAML にエクスポート**

以下の Java の例は、既定設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

既定では、エクスポートされたスライドはプロセスのカレントディレクトリ内の `pres` サブフォルダーに保存されます。空のパスから [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) で解決されます。フォルダーは自動的に作成され、必要な画像も同様に保存されます。

出力フォルダー名は、拡張子を除いたソースファイル名から取得されます。`pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` などと命名されます。入力プレゼンテーションに絶対パスを指定した場合でも、出力フォルダーはカレントディレクトリを基準に作成され、入力ファイルと同じ場所には作成されません。

## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御するには、[IXamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloptions/) インターフェイスを使用します。

出力先をカスタムロケーションに保存するには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を実装し、その実装インスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/) の [setOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) メソッドに渡します。

XAML 出力に非表示スライドを含めるには、以下の Java の例のように `true` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) を呼び出します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **生成されたすべての XAML アーティファクトを取得**

XAML エクスポートでは、エクスポートされた各スライドに対して XAML ドキュメントが生成され、別途画像やサポートリソースが作成されます。デフォルトのファイルシステムセーバーの代わりに、これらのアーティファクトを受け取るためにカスタムの [IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) に割り当てます。XAML オプションを受け取る [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) のオーバーロードでエクスポートを開始します。

### **コールバックのライフサイクルを理解**

エクスポーターは生成された各アーティファクトに対して、[IXamlOutputSaver.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) を個別に呼び出します：

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報を保持してください。
- `data` にはアーティファクトのバイト列が含まれます。画像やその他のバイナリリソースをテキストとしてデコードしてはいけません。
- セーバーは返却する前にデータを保持または永続化する責務があります。例では各バイト配列をアプリケーション所有のメモリにコピーしています。
- エクスポートが成功したとみなすのは、プレゼンテーションの保存操作が戻り、すべてのコールバックが正常に完了した場合のみです。ストレージエラーを無視したり、観測されていないバックグラウンド書き込みを開始したりしないでください。永続化がその後に行われる場合、全体の成功はそのステップが成功した後にのみ報告してください。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) はカスタムセーバーにも適用されます。デフォルト設定 `false` は非表示スライドの XAML ドキュメントを除外します。`true` を指定するとそれらとエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとに 1 つのコールバックがある、あるいは固定されたコールバック順序があると想定しないでください。

### **メモリへエクスポートしアーティファクトを検査**

この完全な例は `pres.pptx` を読み込み、すべてのアーティファクトを [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) に収集し、名前、タイプ、バイト数を出力します。提供された名前は正確に保持されます。重複した名前がある場合、アーティファクトは上書きされずにコレクションが無効とマークされます。例では結果を使用する前にこのチェックを行っています。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // XAML のみをデコードし、テキスト検査が必要な場合にのみ行います。
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

拡張子のチェックは検査に役立ちます。未知のリソースタイプを含むすべてのアーティファクトを保持してください。保存や送信時にはバイト列を変更せずにそのまま扱います。テキスト処理が必要な XAML に対してのみ、UTF-8 で [String コンストラクタ](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) を使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化**

この独立した例はエクスポートを収集し、名前を検証したうえで元のバイト列を ZIP アーカイブに書き込みます。ユニークなアーカイブ名により同時エクスポートジョブが分離されます。ZIP エントリはスラッシュ（/）を使用し、相対ディレクトリを保持します。正規化後に衝突する危険な名前は、書き込まれる前に全体のパッケージを拒否します。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP ディレクトリは、成功を報告する前にクローズすることで確定されました。
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

例では [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) を使用してローカルアーカイブを1つ書き込みます。エクスポーター自体は個別の XAML や画像ファイルを書き込みません。リモートストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えます。エクスポートジョブの識別子と完全な相対アーティファクト名をブロブキーとして使用するか、ジョブ識別子、相対名、バイナリデータをデータベースの行に保存します。すべてのアップロードが完了するかデータベーストランザクションがコミットされた後にジョブを公開します。永続化に失敗した場合は部分的な出力をクリーンアップしてください。

大規模なプレゼンテーションの場合、カスタムセーバーが各アーティファクトを直接アプリケーションストレージに永続化すれば、アプリケーションメモリにエクスポート全体の追加コピーを保持する必要がなくなります。エクスポーター側から見ると、各コールバックは同期的に扱い、宛先がバイトを受け取った後にのみ戻り、失敗は呼び出し元に伝播させてください。

### **リソース名を保持し参照を検証**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持します。すべての生成名が一意であり、リソース参照が有効であると確実に分かっている場合以外は、[Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) のみを使用しないでください。
- 宛先固有の名前検証を適用します。個別ファイルを書き込む場合、ルートパスやディレクトリトラバーサルを拒否し、[Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) で宛先を解決し、意図したエクスポートディレクトリ以下に留まっていること（ディレクトリ区切り文字も含めて）を確認します。書き込み先をリダイレクトできるシンボリックリンクのない、アプリケーションが管理するディレクトリを使用してください。
- エクスポートジョブごとに別々のセーバーとストレージ名前空間を使用します。セパレータ正規化後および宛先の大文字小文字区別ルールに従って衝突を検出してください。
- 公開前に、各 XAML ドキュメントを XML として解析し、画像の `Source` や `ImageSource` 属性などのファイルベースのリソース参照を検査します。各相対 URI をそれを含む XAML アーティファクトのディレクトリに対して解決し、結果のストレージ名を正規化し、対応するマップキー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI と XAML マークアップ式は相対ファイル名とは別に扱ってください。

例えば、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保持すると関係が壊れます。オブジェクトストレージの場合、ジョブプレフィックス以下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにしてください。完了した ZIP を再度開き、エントリ名とリソースバイトを検証し、対象の XAML 環境で代表的なスライドを読み込んで画像が正しく解決されることを確認します。

## **FAQ**

**元のフォントがマシンに存在しない場合、フォントの予測可能性を確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/) で [setDefaultRegularFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) を呼び出します。これは元のフォントが見つからない場合のフォールバックフォントとしてエクスポート時に使用されます。ただし、生成された XAML がフォールバックフォントを参照することや、対象マシンにフォントが存在することを保証するものではありません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を通じて WPF XAML をエクスポートします。他の XAML スタック（UWP や Xamarin.Forms など）との互換性は保証されません。生成されたマークアップは対象環境でテストしてください。

**非表示スライドはサポートされていますか、デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。これらの動作は [XamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) で制御できます。エクスポートが不要な場合は無効にしておいてください。