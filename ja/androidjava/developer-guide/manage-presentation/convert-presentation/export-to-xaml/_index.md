---
title: Android でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint および OpenDocument のスライドを XAML に変換します — 迅速で Office 不要のソリューションで、レイアウトをそのまま保持します。"
---
## **概要**

この記事では、Java 経由で Android 用 Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要、既定設定でプレゼンテーションを XAML に保存する方法、[XamlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/) を使用してエクスポートをカスタマイズする方法（非表示スライドのエクスポートを含む）を示します。また、フォールバック フォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも回答します。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

XAML ファイルはビジュアル デザイナーで操作することも、直接マークアップを書いて編集することもできます。

## **既定オプションでプレゼンテーションを XAML にエクスポート**

次の Java の例は、既定設定でプレゼンテーションを XAML にエクスポートする方法を示しています:

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

既定では、エクスポートされたスライドはプロセスの現在の作業ディレクトリ内の `pres` サブフォルダーに保存されます。このフォルダーは自動的に作成され、必要な画像も同じ場所に保存されます。

出力フォルダー名は、ソース ファイル名から拡張子を除いたものが使用されます。たとえば `pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` などと命名されます。入力プレゼンテーションに絶対パスを渡した場合でも、出力フォルダーは現在の作業ディレクトリに相対的に作成され、入力ファイルと同じ場所には作成されません。

Android では、アプリからアクセス可能な入力ファイルを使用してください。現在の作業ディレクトリは書き込みできないことがあります。下記の例のようにカスタムの出力セーバーを使用してエクスポートをメモリに保持するか、アプリのストレージに書き込んでください。生成される WPF XAML は互換性のあるコンシューマ向けであり、Android のレイアウト リソースではありません。

## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[IXamlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御します。

出力をカスタムの場所に保存するには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ixamloutputsaver/) を実装し、そのインスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/) の [setOutputSaver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) メソッドに渡します。

非表示スライドを XAML 出力に含めるには、以下の Java の例のように `true` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) を呼び出します:

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

XAML エクスポートは、エクスポートされた各スライドごとに XAML ドキュメントを生成し、個別の画像やサポート リソースを生成することがあります。デフォルトのファイルシステム セーバーの代わりに、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ixamloutputsaver/) を [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) に割り当ててこれらのアーティファクトを受け取ります。エクスポートは XAML 固有の [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) オーバーロードで開始し、XAML オプションを受け取ります。

### **コールバック ライフサイクルを理解する**

エクスポーターは生成された各アーティファクトに対して [IXamlOutputSaver.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) を個別に呼び出します:

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報は保持してください。
- `data` はアーティファクトのバイト列を含みます。画像やその他のバイナリ リソースをテキストとしてデコードしてはいけません。
- セーバーはデータを返す前に保持または永続化する責任があります。例では各バイト配列をアプリ所有のメモリにコピーしています。
- プレゼンテーションの保存操作が戻り、すべてのコールバックが正常に完了したときにのみエクスポートを成功とみなします。ストレージエラーを無視したり、監視されていないバックグラウンド書き込みを開始したりしないでください。永続化が後で行われる場合は、そのステップが成功した後にのみ全体の成功を報告します。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) はカスタム セーバーにも適用されます。既定設定 `false` は非表示スライドの XAML ドキュメントを除外します。`true` を渡すと非表示スライドとそれらのエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとにコールバックが1つある、あるいは固定順序になると想定しないでください。

### **メモリにエクスポートしてアーティファクトを検査**

この完全な例は `pres.pptx` を読み込み、すべてのアーティファクトを [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) に収集し、名前、タイプ、バイト数を出力します。提供された名前は正確に保持されます。重複した名前がある場合はコレクションを無効として扱い、サイレントに上書きしません。例では結果を使用する前にこのチェックを行います。

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

    // XAML のみをデコードし、テキスト検査が必要な場合にのみ実行します。
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

拡張子のチェックは検査に有用です。未知のリソースタイプを含むすべてのアーティファクトを保持してください。保存または転送時にバイトは変更せずにそのまま保持します。テキスト処理が必要な XAML のみ UTF-8 で [String コンストラクタ](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) を使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化**

この独立した例はエクスポートを収集し、名前を検証して、元のバイトを ZIP アーカイブに書き込みます。`/path/to/app/files` を Android コンテキストの [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) が返すパスに置き換えてください。固有のアーカイブ名は同時実行エクスポート ジョブを分離します。ZIP エントリはスラッシュ (`/`) を使用し、相対ディレクトリを保持します。正規化後に衝突する危険な名前や安全でない名前は、書き込まれる前にパッケージ全体を拒否します。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP ディレクトリは、成功を報告する前にクローズすることで確定されています。
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

例では [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) を使用してローカル アーカイブを書き込みます。エクスポーター自体は個別の XAML や画像ファイルを書き込みません。リモート ストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えてください。エクスポート ジョブ ID と完全な相対アーティファクト名を BLOB キーとして使用するか、ジョブ ID、相対名、バイナリ データをデータベース行に保存します。すべてのアップロードが完了し、データベース トランザクションがコミットされた後にのみジョブを公開し、永続化に失敗した場合は部分出力をクリーンアップしてください。

大規模なプレゼンテーションでは、カスタム セーバーが各アーティファクトを直接アプリのストレージに永続化できるようにすれば、アプリ メモリにエクスポート全体の余分なコピーを保持する必要がなくなります。エクスポーターの観点から各コールバックは同期的に保ち、宛先がバイトを受け入れた後にだけ戻り、失敗は呼び出し元に伝搬させます。

### **リソース名を保持し参照を検証**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意であり、リソース参照が有効であることが保証できない限り、単に `File.getName` のみを使用しないでください。
- 宛先固有の名前検証を適用します。個別ファイルを書き込む場合は、ルート パスやディレクトリ トラバーサル セグメントを拒否し、[File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) で宛先を解決し、意図したエクスポート ディレクトリ以下にとどまっているか（ディレクトリ区切り文字を含めて）確認します。シンボリック リンクで書き込み先がリダイレクトされないよう、アプリ制御のディレクトリを使用してください。
- 各エクスポート ジョブごとに別々のセーバーとストレージ名前空間を使用します。区切り文字正規化後および宛先の大文字小文字区別ルールに従って衝突を検出してください。
- 公開前に各 XAML ドキュメントを XML として解析し、`Source` や `ImageSource` 属性などのファイルベースのリソース参照を検査します。各相対 URI をその XAML アーティファクトのディレクトリに対して解決し、結果のストレージ名を正規化して、対応するマップ キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI や XAML マークアップ式は相対ファイル名とは別に扱ってください。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保持すると関係が壊れます。オブジェクト ストレージの場合、ジョブ プレフィックス配下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにしてください。完了した ZIP を再度開き、エントリ名とリソース バイトを検証し、対象 XAML 環境で代表的なスライドを読み込んで画像が正しく解決することを確認します。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) を呼び出します。このフォントは元のフォントが欠落しているときのフォールバックとしてエクスポート時に使用されます。ただし、生成された XAML がフォールバック フォントを参照することや、対象マシンにそのフォントが存在することを保証するものではありません。XAML が表示される環境に、参照されるフォントが確実に存在するようにしてください。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

Aspose.Slides は公開 API を通じて WPF 用 XAML をエクスポートします。他の XAML スタック（UWP や Xamarin.Forms など）との互換性は保証されていません。生成されたマークアップは対象環境でテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

既定では非表示スライドは含まれません。エクスポートを制御するには [XamlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) を使用します。必要ない場合はこのオプションを無効のままにしてください。