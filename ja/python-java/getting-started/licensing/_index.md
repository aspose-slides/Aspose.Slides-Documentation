---
title: ライセンス
type: docs
weight: 80
url: /ja/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- ライセンスファイル
- 一時ライセンス
- 従量課金ライセンス
- 評価制限
description: "Aspose.Slides for Python via Java で、ファイルベース、バイトベース、または従量課金ライセンスを適用し、アプリケーションから評価制限を解除します。"
---
## **概要**

Aspose.Slides for Python via Java は評価モードまたはライセンスモードで実行できます。本記事では、ファイルまたはバイト列からライセンスを適用する方法と、メーター制ライセンスの構成方法について説明します。

購入オプションについては、[価格情報](https://purchase.aspose.com/pricing/slides/ja/family)をご覧ください。一般的なライセンスおよび購入に関する質問は、[購入ポリシーとFAQ](https://purchase.aspose.com/policies)をご覧ください。

評価の制限と一時ライセンスのリクエスト方法については、[Aspose.Slides の評価](/slides/ja/python-java/evaluate-aspose-slides/)をご覧ください。購入したライセンスファイルと同じ方法で一時ライセンスを適用します。

## **ライセンスについて**

ライセンスファイルには、製品名、ライセンス対象開発者数、サブスクリプションの有効期限などの情報が含まれます。ファイルはデジタル署名された XML です。

{{% alert color="warning" title="警告" %}}
ライセンスファイルを編集しないでください。余分な改行があるだけでもデジタル署名が無効になる可能性があります。
{{% /alert %}}

ライセンスはアプリケーションまたはプロセスごとに一度だけ、プレゼンテーションの作成やその他の Aspose.Slides 操作を行う前に適用してください。ライセンスファイルの場合は、[License](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/) クラスを使用します。メーター制ライセンスは、ライセンスファイルの代わりに公開鍵と秘密鍵のペアを使用します。

## **ライセンスの適用**

以下の例は、Aspose.Slides for Python via Java とその前提条件がインストールされていることを前提としています。各例は JVM を起動し、API をインポートし、ライセンスを適用する単独スクリプトです。アプリケーションでは、ライセンスを適用した後にプレゼンテーション操作を実行し、すべての Aspose.Slides の処理が完了した後にのみ JVM をシャットダウンしてください。

### **ファイルからライセンスを適用**

ライセンスファイルのパスを [License.setLicense](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#setLicense) に渡します。`Aspose.Slides.lic` をライセンスファイルへのパスに置き換えてください。

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
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行してください。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

拡張子を含めた正確なファイル名を使用してください。たとえば、ファイル名が `Aspose.Slides.lic.xml` の場合、パスに `.xml` を含めます。絶対パスを使用すると、アプリケーションの作業ディレクトリに関する曖昧さを回避できます。

この例では、ライセンスが適用されているかどうかを確認するために [License.isLicensed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#isLicensed) を使用しています。

### **バイト列からライセンスを適用**

ライセンスが Python のバイト列として利用可能な場合は、[License.setLicenseFromBytes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/license/#setLicenseFromBytes) を使用します。以下の例では、ファイルをバイナリモードで読み取り、ライセンスを適用する前に閉じています。

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
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行してください。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

元のバイト列はそのまま保持してください。ライセンス内容をデコードしたり、再フォーマットしたり、その他の方法で変更しないでください。

## **メーター制ライセンスの適用**

メーター制ライセンスは API の使用量に基づいて課金されます。メーター制ライセンスを取得したら、[Metered.setMeteredKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/#setMeteredKey) を使用して公開鍵と秘密鍵を適用します。[Metered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) オブジェクトを初期化し、アプリケーション起動時にキーを一度適用してください。

以下の例では、`ASPOSE_METERED_PUBLIC_KEY` と `ASPOSE_METERED_PRIVATE_KEY` 環境変数からキーを読み取ります。スクリプトを実行する前に両方の変数を設定してください。

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
        # JVM をシャットダウンする前に、ここでプレゼンテーション操作を実行してください。
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="注" %}}
メーター制ライセンスは、キーの検証と使用量の報告のためにインターネット接続が必要です。秘密鍵はソースコードやログに含めないでください。接続性や課金の詳細については、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。
{{% /alert %}}

## **よくある質問**

**ライセンス購入後に別のパッケージをインストールする必要がありますか？**

いいえ。評価時に使用したのと同じパッケージにライセンスを適用してください。

**各プレゼンテーションごとにライセンスを適用すべきですか？**

いいえ。アプリケーションの起動時に一度だけ適用し、プレゼンテーションの作成または読み込みの前に行ってください。

**ライセンスファイルの名前を変更できますか？**

はい。コード内で正確な新しいファイル名を使用し、ファイル内容は変更しないでください。

**バイト列ベースの例で一時ライセンスを使用できますか？**

はい。一時ライセンスファイルをバイト列として読み取り、購入したライセンスと同様の方法で適用してください。