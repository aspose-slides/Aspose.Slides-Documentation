---
title: Python via Javaでプレゼンテーション警告を処理する
type: docs
weight: 90
url: /ja/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- 警告ポリシー
- データ損失
- ソース破損
- 互換性問題
- フォント置換
- デジタル署名
- プレゼンテーション読み込み
- プレゼンテーションレンダリング
- プレゼンテーション変換
- プレゼンテーション保存
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションの読み込み、レンダリング、変換、保存時に警告を収集、分類、対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、または保存中に回復可能な問題を報告できます。例として、破損したソースレコード、保持できないコンテンツ、フォント置換、ターゲット形式の制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

`jpype.JProxy` を使用して `IWarningCallback` インターフェイスを実装し、`IWarningInfo` が提供する `getWarningType` と `getDescription` の値を確認します。警告を受け入れる場合は [ReturnAction.Continue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/returnaction/#Continue) を返し、操作を停止する場合は [ReturnAction.Abort](https://reference.aspose.com/slides/ja/python-java/aspose.slides/returnaction/#Abort) を返します。

プレゼンテーションのオープン時に発生する警告には [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setWarningCallback) を使用します。レンダリングおよびエクスポートオプションのクラスは [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setWarningCallback) を継承し、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成するときは各コールバックインスタンスを操作ステージに関連付けます。

## **警告と例外**

警告は、コールバックが `ReturnAction.Continue` を返すことで Aspose.Slides が回復できる状態を示します。例外は要求された操作が通常通り完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction.Abort` を返すと、警告ディスパッチャは例外をスローして現在の操作を終了させます。スローされる例外は操作とプレゼンテーション形式に依存します。例えば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxreadexception/) または [PptReadException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptreadexception/) が発生し、保存やエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxexception/) が発生することがあります。例外は操作の境界で処理し、警告レポートを使用して終了がアプリケーションポリシーによるものかを判断します。コールバックは `ReturnAction.Abort` を返す前に警告を記録し、理由がアプリケーションで利用できるようにします。

## **警告カテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/) クラスは、以下のカテゴリに対応する整数定数を提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#SourceFileCorruption) | ソースプレゼンテーションに破損が含まれており、元の形式で保存されたドキュメントが使用できなくなる可能性があります。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#DataLoss) | ロードまたは保存後にテキスト、チャート、画像、その他のデータが欠落している可能性があります。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | プレゼンテーションの重要な書式が失われる可能性があります。 | 厳格な検証モードでは中止し、それ以外は記録して続行。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | 限定的な書式差異が発生する可能性があります。 | 診断のために記録し、続行。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果が一部のアプリケーションや旧バージョンで正しく開かれない、または動作しない可能性があります。 | 互換性が必須でない限りログに記録して続行。 |
| [UnexpectedContent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/warningtype/#UnexpectedContent) | ソースにサポートされていない、または認識できないコンテンツが含まれており、その影響はまだ不明です。 | 記録して続行するか、厳格なポリシーではエラーとして扱う。 |

カテゴリはポリシー判断の指針とすべきです。診断のために `getDescription` が返す値を保存しますが、メッセージ文は警告シナリオや製品バージョンにより変わるため、アプリケーションロジックでその文言に依存しないでください。

## **警告の収集と分類**

以下の例は、全処理パイプライン用にアプリケーションレベルの単一レポートを使用します。別々のコールバックインスタンスが読み込み、レンダリング、PDF 変換、PPTX 保存からの警告にラベルを付けます。ポリシーはソースの破損やデータ損失時に中止し、主要な書式損失時にはオプションで中止、その他の警告は続行します。

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

主要な書式差異が許容できる場合は、`WarningPolicy` を構築する際に `abort_on_major_formatting_loss` に `False` を渡します。互換性の問題、軽微な書式損失、予期しないコンテンツは、操作が続行されてもレポートに保持されます。アプリケーションがそれらのカテゴリのいずれかを拒否する必要がある場合は、`WarningPolicy.get_action` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります：

- **デジタル署名:** 署名されたプレゼンテーションは、読み込み時に処理中に署名が失われる旨の警告を出すことがあります。Aspose.Slides はこの `DataLoss` 状態を `IPresentationSignedWarningInfo` を通じて報告します。ロード段階のコールバックにより、アプリケーションはファイルを拒否するか、報告された損失を明示的に受け入れることができます。
- **フォント置換:** 使用できないフォントは、スライドのレンダリングまたはエクスポート中に置き換えられることがあります。フォント置換の警告は `DataLoss` として報告されるため、上記の厳格なポリシーでは、アプリケーションが特定の置換を視覚的に受容できる場合でも中止します。この動作を確認するには、実行時に利用できないフォントでテキストが含まれる入力プレゼンテーションを使用してください。警告の説明には置換が示されます。必要なフォントを設定するか、[フォント置換ルール](/slides/ja/python-java/font-substitution/) を構成してから再試行してください。
- **サポートされていないまたは予期しないコンテンツ:** ローダーが認識できないプレゼンテーションレコードや機能に遭遇することがあります。このような警告は `UnexpectedContent` を使用する場合や、データや書式が影響を受けていることが分かっている場合はより重大なカテゴリになることがあります。
- **形式の互換性:** 別のプレゼンテーション形式に保存すると、機能が省略されたり、いくつかのアプリケーションで動作が異なる結果になることがあります。例えば、8 本を超える水平または垂直の描画ガイドを含むプレゼンテーションをレガシー PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックは損失を記録して続行するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **読み込み動作:** 読み込みオプションやレガシーの動作でも警告が発生することがあります。例として、`IObsoletePresLockingBehaviorWarningInfo` は、廃止されたプレゼンテーションロック動作の使用を `CompatibilityIssue` として識別します。

警告はソースドキュメント、ターゲット形式、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を生成する、またはシナリオが常に単一のカテゴリにマッピングされると想定しないでください。

## **中止された操作の安全な処理**

コールバックが `ReturnAction.Abort` を返した場合、ロードに失敗したオブジェクトを使用せず、レンダリングまたは保存の出力が完了したと想定しないでください。操作は出力ファイルを作成した時点で終了することがあり、完了前に終了する可能性があります。

検証済みの結果は `validated-output.pptx` のような別パスに保存してください。操作が正常に完了し、警告レポートがアプリケーションポリシーを満たし、出力が開いて確認できた場合にのみ既存のプレゼンテーションを置き換えます。これにより、部分的または拒否された結果で有効なソースファイルを上書きすることを防げます。

空の警告レポートは、すべてのソース機能が保持されたことの保証ではありません。アプリケーションが要求する追加のコンテンツや視覚的チェックを実施してください。また、[Open Presentations](/slides/ja/python-java/open-presentation/) と [Save Presentations](/slides/ja/python-java/save-presentation/) も参照してください。

## **FAQ**

**警告コールバックはすべての Aspose.Slides エラーを処理できますか？**

いいえ。回復可能な条件が警告として報告された場合にのみ処理します。コールバックとは無関係に発生する例外は、ロード、レンダリング、変換、または保存の呼び出しを囲む形でアプリケーション側で処理する必要があります。

**`ReturnAction.Continue` を返すことで同一の出力が保証されますか？**

いいえ。処理を続行できるだけです。報告された状態によりデータ、書式、互換性の違いが生じる可能性があるため、収集した警告タイプと説明を確認してください。

**アプリケーションは警告を生成した操作をどのように特定できますか？**

各操作ごとにコールバックインスタンスを作成し、例に示すように `getWarningType` と `getDescription` が返す値とともにアプリケーション定義のステージを保存します。