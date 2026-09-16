---
title: PHPでプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションからXAMLへ
type: docs
weight: 30
url: /ja/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して PowerPoint と OpenDocument のスライドを XAML に変換します — 迅速で Office 不要のソリューションで、レイアウトをそのまま保持します。"
---
## **概要**

このドキュメントでは、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な紹介、デフォルト設定でプレゼンテーションを XAML に保存する方法、[XamlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/) を使用したエクスポートのカスタマイズ（非表示スライドのエクスポートを含む）を示します。また、フォントのフォールバック、XAML スタック互換性、非表示スライドのエクスポート動作に関する一般的な質問にも回答します。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

XAML ファイルはビジュアル デザイナで操作することも、直接マークアップを記述・編集することもできます。

## **デフォルト オプションでプレゼンテーションを XAML にエクスポートする**

次の PHP サンプルは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。例を実行する前に PHP Java Bridge を初期化し、`aspose.slides.php` をロードしてください。`pres.pptx` を Java Bridge サーバーの作業ディレクトリに配置するか、サーバーからアクセス可能な絶対パスを指定してください。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

デフォルトでは、エクスポートされたスライドは Java Bridge サーバーの現在の作業ディレクトリ内の `pres` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同じ場所に保存されます。

出力フォルダー名は、拡張子を除いた元ファイル名から取得されます。`pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` といった名前になります。入力プレゼンテーションに絶対パスを渡した場合でも、出力フォルダーは Java Bridge サーバーの作業ディレクトリを基準に作成され、入力ファイルと同じ場所に作成されるわけではありません。

## **カスタム オプションでプレゼンテーションを XAML にエクスポートする**

[IXamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御できます。

出力先をカスタム位置に指定するには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を実装した Java プロキシを作成し、そのインスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/) の [setOutputSaver](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/#setOutputSaver) メソッドに渡します。

XAML 出力に非表示スライドを含めるには、以下の PHP サンプルのように `true` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **生成されるすべての XAML アーティファクトを取得する**

XAML エクスポートは、エクスポートされた各スライドごとに XAML ドキュメントを生成し、画像やサポート リソースを別途保存します。デフォルトのファイルシステム保存機構の代わりに、カスタム [IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/#setOutputSaver) に割り当てて、これらのアーティファクトを取得してください。エクスポートは、XAML オプションを受け取る XAML 固有の [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) オーバーロードで開始します。

PHP Java Bridge の `java_closure` 関数は PHP オブジェクトを Java インターフェイスとして公開します。エクスポートが完了するまで、PHP のセーバーとそのプロキシの両方を保持してください。インターフェイスリンクは、プロキシが実装する Java API を指します。

### **コールバック ライフサイクルの理解**

エクスポーターは、生成された各アーティファクトに対して [IXamlOutputSaver::save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) を個別に呼び出します。

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報は保持してください。
- `data` にはアーティファクトのバイト列が格納されます。画像やその他のバイナリ リソースはテキストとしてデコードしないでください。
- セーバーはデータを保持または永続化したうえで戻り値を返す責任があります。サンプルでは各 Java バイト配列をアプリケーションが所有する PHP バイナリ文字列に変換しています。
- プレゼンテーションの保存処理が戻り、すべてのコールバックが正常に完了したときのみエクスポートを成功とみなしてください。ストレージ エラーを無視したり、バックグラウンド書き込みを開始したりしないでください。永続化が後で行われる場合は、そのステップが成功した後に全体の成功を報告してください。

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) はカスタム セーバーにも適用されます。デフォルト設定の `false` は非表示スライドの XAML ドキュメントを除外します。`true` を指定すると、非表示スライドとそれらのエクスポートに必要なすべてのリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドあたり 1 コールバックや固定順序を前提にしないでください。

### **メモリ上にエクスポートしアーティファクトを検査する**

この完全なサンプルは `pres.pptx` を読み込み、すべてのアーティファクトを PHP の連想配列（バイナリ文字列）に格納し、名前・型・バイト数を出力します。提供された名前はそのまま保持します。重複名がある場合はコレクションを無効として扱い、上書きせずにエラーとします。サンプルは結果を使用する前にこのチェックを行います。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // オプションの検査のために、XAML のみを UTF-8 テキストとして扱います。
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

拡張子チェックは検査に有用です。すべてのアーティファクト（未知のリソース種別も含む）を保持し、バイトは変更せずに保存または転送してください。PHP 文字列はゼロバイトを含むバイナリ データを保持できます。XAML を調査するときだけ文字列を UTF-8 テキストとして扱い、画像やリソースのバイト列を変換しないでください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化する**

この独立したサンプルはエクスポート結果を収集し、名前を検証したうえで元のバイト列を ZIP アーカイブに書き込みます。並行エクスポート ジョブを分離するために、専用のジョブ ディレクトリを作成します。このサンプルは ZIP 対応の PHP Phar 拡張が必要です。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリ構造を保持します。正規化後に衝突する名前や安全でない名前は、書き込み前にパッケージ全体を破棄します。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

サンプルは [PharData](https://www.php.net/manual/en/class.phardata.php) を使用して、PHP プロセスの作業ディレクトリにローカル ZIP を作成します。エクスポーター自体は個別の XAML や画像ファイルを書き出しません。リモート ストレージに保存する場合は、アーカイブ作成段階をバイナリ文字列のアップロードに置き換えてください。エクスポート ジョブ ID と相対アーティファクト名をブロブ キーとして使用するか、ジョブ ID、相対名、バイナリ データをデータベース行に保存します。すべてのアップロードが完了した後、またはデータベース トランザクションがコミットされた後にジョブを公開してください。永続化に失敗した場合は、部分的な出力をクリーンアップします。

サイズの大きいプレゼンテーションの場合、カスタム セーバーで各アーティファクトを直接アプリケーション ストレージに永続化すれば、メモリ上にエクスポート全体のコピーを保持する必要がなくなります。エクスポーターの観点からは、コールバックは同期的に実装し、バイトを受け取った先が受領したことを確認した後にだけ戻り値を返してください。失敗は呼び出し元に伝搬させます。

### **リソース名を保持し参照を検証する**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意でリソース参照が有効であることが保証できる場合以外は、`basename` のみを使用しないでください。
- 宛先固有の名前検証を適用します。個別ファイルを書き出す場合は、ルート パスや遡りセグメントを除外し、宛先を絶対パスに解決したうえで、エクスポート ディレクトリ以下に収まっていることをチェックしてください。シンボリック リンクで書き込み先が変わらないよう、アプリケーション管理下のディレクトリを使用します。
- エクスポート ジョブごとに別々のセーバーとストレージ名前空間を使用し、区切り文字正規化後および宛先の大小文字判定規則に従って衝突を検出してください。
- 公開前に各 XAML ドキュメントを XML として解析し、`Source` や `ImageSource` といったファイルベースのリソース参照を調べます。相対 URI をその XAML アーティファクトのディレクトリに対して解決し、正規化したストレージ名がマップキー、ZIP エントリ、または保存オブジェクトとして存在するか確認してください。外部 URI や XAML マークアップ式は、相対ファイル名とは別に扱います。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保存すると関係が壊れます。オブジェクト ストレージを使用する場合は、ジョブ プレフィックス以下に同じレイアウトを保持し、これらのリソース URL が XAML コンシューマーからアクセスできるようにしてください。完成した ZIP を再度開き、エントリ名とリソース バイトを検証し、対象 XAML 環境で代表的なスライドをロードして画像が正しく解決することを確認します。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを保証するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) を呼び出してください。エクスポート時に元フォントが見つからない場合のフォールバック フォントとして使用されます。ただし、生成された XAML がフォールバック フォントを参照することや、ターゲット マシンにそのフォントが存在することは保証されません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

Aspose.Slides は公開 API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックでの互換性は保証されません。対象環境で生成されたマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。