---
title: PHP を使用したプレゼンテーションへのフォント埋め込み
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/php-java/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して PowerPoint の埋め込みフォントを管理します。フォントを追加、取得、削除、圧縮してテキストの外観を保ち、ファイルサイズを削減します。"
---
## **はじめに**

埋め込みフォントはフォントデータを PowerPoint プレゼンテーション内に保存します。ビューアが埋め込みフォントに対応している場合、対象システムにフォントがインストールされていなくてもそのフォントでテキストを表示できます。これにより改行や文字間隔、スライドレイアウトが保持されます。

Aspose.Slides for PHP via Java を使用すると、[FontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/) クラス（[Presentation::getFontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getFontsManager) が返す）を通じて埋め込みフォントの取得、追加、削除ができます。また、プレゼンテーションで使用されていない文字を削除することで、埋め込みフォントデータのサイズを縮小することも可能です。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、そのフォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) を使用してプレゼンテーションに保存されているフォントを一覧表示できます。削除する場合は、その一覧から取得したフォントを [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) に渡してからプレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` に埋め込まれているフォントを一覧表示し、Calibiri が存在すれば削除します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

埋め込みフォントを削除すると、保存されていたフォントデータが失われますが、テキストに割り当てられたフォント自体は変更されません。対象システムにフォントがインストールされていればテキストは引き続きそのフォントで表示されます。そうでない場合は、[フォント置換](/slides/ja/php-java/font-substitution/) が行われ、レイアウトに影響を与える可能性があります。

## **フォントデータと埋め込み権限の検査**

埋め込む前にフォントを検査するには、[FontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/) クラスを使用します。[FontsManager::getFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getFonts) でプレゼンテーションで使用されているフォントを取得し、各フォントについて [FontData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontstyletype/) の値を渡して [FontsManager::getFontBytes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getFontBytes) を呼び出します。このメソッドはそのフォントスタイルのバイナリデータを返すか、該当フォントまたはスタイルが無い場合は `null` を返します。`null` が返された場合は、バイト配列が必要な [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) に渡さないでください。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embeddinglevel/) はフォントに格納された埋め込み制限を示すフラグ列挙型です。

- `Installable` は埋め込みと他システムへの永続的インストールを許可します（フォントライセンスに従う）。
- `Restricted` は唯一の使用許可フラグがこれの場合、フォント所有者の許可が無ければ埋め込みを禁止します。
- `PreviewPrint` は閲覧と印刷の一時的使用を許可します。文書は読み取り専用である必要があります。
- `Editable` は一時的使用を許可し、文書の編集と保存を可能にします。
- `NoSubsetting` は部分的なグリフの埋め込みを禁止する追加制限です。このフラグがある場合はすべての文字を埋め込む必要があります。
- `BitmapOnly` はアウトラインデータではなくビットマップストライクのみの埋め込みを許可する追加制限です。フォントにビットマップストライクが無い場合、埋め込みはできません。

最初の４つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット演算で修飾子を確認してください。`Installable` の値は 0 のため、使用許可ビットをマスクし、結果が `Installable` と等しいかで判定します。現在のフォントは最大で１つの使用許可ビットのみ設定すべきです。古いフォントで複数設定されている場合は、以下のヘルパーが最も制限の緩い権限を選択します：`Editable` → `PreviewPrint` → `Restricted`。

次の例は `FontsManager::getFonts` が返すすべてのフォントについて、通常・太字・斜体・太字斜体のデータを監査します。利用できないスタイル、制限付きフォント、ビットマップ専用フォント、プレビュー・印刷のみ許可されたフォント（出力は編集可能になるため除外）、既に埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合は、そのフォントファミリのすべての文字を埋め込みます。

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この検査は各フォントファイルにエンコードされた制限を報告します。ライセンスの付与や、フォントを合法的に取得したことの証明、埋め込みコピー配布前のフォント使用許諾契約の確認を代替するものではありません。

## **埋め込みフォントの追加**

[FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) を使用してフォントを埋め込めます。オーバーロードにより、[FontData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embedfontcharacters/) 列挙型で埋め込む文字を制御します。

- [All](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受取側がプレゼンテーションを編集して新しいテキストを入力する必要がある場合に使用してください。
- [OnlyUsed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embedfontcharacters/) はプレゼンテーションで使用された文字だけを埋め込み、ファイルサイズを削減します。主に閲覧用の完成したプレゼンテーション向けに選択してください。

次の例は `Fonts.pptx` で使用されているフォントを [FontsManager::getFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getFonts) で取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントはコード実行マシンにインストールされている必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **埋め込みフォントの圧縮**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#compressEmbeddedFonts) は未使用文字を削除して埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減はプレゼンテーション内の未使用フォントデータ量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

受取側が後でテキストを追加する可能性がある場合は、元のファイルを残しておいてください。圧縮時に削除された文字は埋め込みフォントからは利用できなくなります（最初にすべての文字を埋め込んでいた場合でも同様です）。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかはどうやって確認できますか？**

プレゼンテーションをレンダリングする環境で [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/#getSubstitutions) を呼び出し、Aspose.Slides が置換するフォントを確認してください。また、[フォント置換](/slides/ja/php-java/font-substitution/) の設定や [フォントフォールバック](/slides/ja/php-java/fallback-font/) ルールもチェックしてください。フォールバックは欠損文字を処理しますが、フォント自体に含まれない文字は埋め込みだけでは解決できません。

**Arial や Calibri といった一般的なフォントは埋め込むべきでしょうか？**

対象環境に基づいて判断してください。すべてのマシンに必要なフォントが既にインストールされている場合、埋め込みは不要なファイルサイズ増加につながります。受取側やサーバーにフォントが無い可能性がある場合は、ライセンスが許可する範囲で埋め込むことで期待通りの外観を維持できます。