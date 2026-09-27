---
title: ライセンス
type: docs
weight: 80
url: /ja/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- ライセンス ファイル
- 一時ライセンス
- メーター制ライセンス
- 評価制限
description: "Aspose.Slides for Python via Java でファイル、バイトベース、またはメーター制のライセンスを適用し、アプリケーションから評価制限を解除します。"
---
## **概要**

Aspose.Slides for Python via Java は評価モードまたはライセンスモードで実行できます。評価モードでは、保存する各プレゼンテーションのすべてのスライドに評価用透かしテキストボックスが追加され、プレゼンテーションからコードが読み取るテキストが切り捨てられます。この記事では、ファイルまたはバイト配列からライセンスを適用する方法と、メーター制ライセンスの構成方法について説明します。

購入オプションについては、[価格情報](https://purchase.aspose.com/pricing/slides/ja/family)をご覧ください。一般的なライセンスおよび購入に関する質問は、[購入ポリシーと FAQ](https://purchase.aspose.com/policies)をご参照ください。

評価の制限と一時ライセンスの取得方法については、[Aspose.Slides の評価](/slides/ja/python-java/evaluate-aspose-slides/)をご覧ください。購入したライセンス ファイルと同じ方法で一時ライセンスを適用します。

## **ライセンスについて**

ライセンス ファイルには、製品名、許可された開発者数、サブスクリプションの有効期限などの情報が含まれます。ファイルはデジタル署名された XML です。

{{% alert color="warning" title="Warning" %}}
ライセンス ファイルを編集しないでください。余分な改行でもデジタル署名が無効になる可能性があります。
{{% /alert %}}

プレゼンテーションを作成したり、その他の Aspose.Slides 操作を行う前に、アプリケーションまたはプロセスごとに一度だけライセンスを適用してください。ライセンス ファイルを使用する場合は、[License](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/) クラスを使用します。メーター制ライセンスはライセンス ファイルの代わりに公開鍵と秘密鍵のペアを使用します。

## **ライセンスを適用する**

以下の例は、Aspose.Slides for Python via Java とその前提条件がインストールされていることを前提としています。各例は JVM を起動し、API をインポートし、ライセンスを適用する単独スクリプトです。アプリケーションでは、ライセンス適用後にプレゼンテーションの操作を行い、すべての Aspose.Slides 作業が完了した後にのみ JVM をシャットダウンしてください。

### **ファイルからライセンスを適用する**

[License.setLicense](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#setLicense) にライセンス ファイルのパスを渡します。`Aspose.Slides.lic` を実際のライセンス ファイルのパスに置き換えてください。

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行します。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

拡張子を含めた正確なファイル名を使用してください。たとえばファイル名が `Aspose.Slides.lic.xml` の場合、パスに `.xml` を含めます。絶対パスを使用すると、アプリケーションの作業ディレクトリに関する曖昧さを回避できます。

この例では、[License.isLicensed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#isLicensed) を使用してライセンスが適用されたかどうかを確認しています。

### **バイト配列からライセンスを適用する**

ライセンスが Python のバイト列として利用可能な場合は、[License.setLicenseFromBytes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#setLicenseFromBytes) を使用します。以下の例はバイナリ モードでファイルを読み取り、ライセンスを適用する前に閉じています。

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行します。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

元のバイト列をそのまま保持してください。ライセンス コンテンツをデコード、再フォーマット、またはその他の方法で変更しないでください。

## **メーター制ライセンスを適用する**

メーター制ライセンスは API 使用量に応じて課金されます。メーター制ライセンスを取得したら、[Metered.setMeteredKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/#setMeteredKey) を使用して公開鍵と秘密鍵を適用します。[Metered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) オブジェクトを初期化し、アプリケーション起動時にキーを一度だけ設定してください。

以下の例は、`ASPOSE_METERED_PUBLIC_KEY` と `ASPOSE_METERED_PRIVATE_KEY` 環境変数からキーを読み取ります。スクリプト実行前に両方の変数を設定してください。

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行します。
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
メーター制ライセンスはキーの検証と使用量の報告のためにインターネット接続が必要です。秘密鍵はソースコードやログに残さないようにしてください。接続と課金の詳細は [メーター制ライセンス FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。
{{% /alert %}}

## **FAQ**

**ライセンス購入後に別のパッケージをインストールする必要がありますか？**

いいえ。評価に使用したのと同じパッケージにライセンスを適用してください。

**各プレゼンテーションごとにライセンスを適用する必要がありますか？**

いいえ。プレゼンテーションの作成または読み込みの前に、アプリケーション起動時に一度だけ適用してください。

**ライセンス ファイルの名前を変更しても構いませんか？**

はい。コード内で新しい正確なファイル名を使用し、ファイル内容は変更しないでください。

**バイト配列ベースの例で一時ライセンスを使用できますか？**

はい。一時ライセンス ファイルをバイトとして読み取り、購入したライセンスと同じ方法で適用してください。