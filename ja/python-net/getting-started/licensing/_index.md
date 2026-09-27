---
title: ライセンス
type: docs
weight: 80
url: /ja/python-net/licensing/
keywords:
- ライセンス
- 一時ライセンス
- ライセンス設定
- ライセンス使用
- ライセンス検証
- ライセンスファイル
- 評価版
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET におけるライセンスの適用、管理、トラブルシューティング方法を学びます。ステップバイステップのライセンスガイドで、フル機能への継続的なアクセスを確保しましょう。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版はライセンス版と同じ機能を提供しますが、保存する各プレゼンテーションのすべてのスライドに評価用の透かしが追加され、プレゼンテーションからコードが読み取るテキストは切り詰められます。

## **Aspose.Slides の評価**

**Aspose.Slides for Python via .NET** の評価版は、[ダウンロードページ](https://pypi.org/project/Aspose.Slides/)から入手できます。評価版はライセンス製品と同じ機能を提供します。評価パッケージは購入版と同一で、ライセンスを適用するコードを数行追加すればライセンス化されます。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/pricing/slides/python-net/)してください。利用可能なサブスクリプションオプションを確認することをお勧めします。質問がある場合は Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、1 年間のサブスクリプションが含まれ、期間中の新バージョンや修正への無料アップグレードが提供されます。ライセンスユーザーも評価ユーザーも、無制限の無料テクニカルサポートを受けられます。

**評価版の制限**

* ライセンスが適用されていない評価版はフル機能ですが、保存する各プレゼンテーションのすべてのスライドに評価用の透かしテキストボックスが追加されます。
* プレゼンテーションからコードが読み取るテキストは先頭数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは完全に保存されます。

{{% alert color="info" title="注意" %}}
制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) ページをご覧ください。
{{% /alert %}}

## **Aspose.Slides のライセンス管理**

* 評価版はライセンスを購入し、数行のコードで適用するとライセンス化されます。
* ライセンスはプレーンテキストの XML ファイルで、製品名、対象開発者数、サブスクリプション有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。改行一つでも無効になります。
* Aspose.Slides for Python via .NET は、指定したパスにあるライセンスを検索します。相対パスやパスなしのファイル名は、現在の作業ディレクトリを基準に解決されます。作業ディレクトリは必ずしも Python スクリプトがあるフォルダーとは限りません。
* 評価制限を回避するには、Aspose.Slides を使用する前にライセンスを設定してください。アプリケーションまたはプロセスごとに一度だけ設定すれば足ります。

{{% alert color="info" title="注意" %}}
[従量課金ライセンス](/slides/ja/python-net/metered-licensing/) もご確認ください。
{{% /alert %}}

## **ライセンスの適用方法**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="info" title="注意" %}}
Aspose.Slides はライセンス管理用に [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) クラスを提供しています。
{{% /alert %}}

{{% alert color="warning" title="警告" %}}
新しいライセンスはバージョン 21.4 以降でのみ有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスを認識しません。
{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、[set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) メソッドにライセンスファイルのパスを渡すことです。以下の例のようにファイル名だけを渡すと、Aspose.Slides は現在の作業ディレクトリでそのファイルを探します。

以下の Python コードはライセンスファイルの設定方法を示しています。

```py
import aspose.slides as slides

# ライセンスクラスのインスタンスを作成します。 
license = slides.License()

# ライセンスファイルのパスを設定します。
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="警告" %}}
ライセンスファイルを別ディレクトリに置く場合、[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) を呼び出す際のパスの最後にあるファイル名が実際のライセンスファイル名と一致している必要があります。

たとえば、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更し、コード内でそのフルパス（末尾が Aspose.Slides.lic.xml）を [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) に渡します。
{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードすることもできます。以下の Python 例はストリームからライセンスを適用する方法を示しています。

```py
import aspose.slides as slides

# ライセンスクラスのインスタンスを作成します。
license = slides.License()

# ストリームからライセンスを設定します。
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **ライセンスの検証**

ライセンスが正しく適用されたか確認するには、検証を行います。以下の Python コードはライセンスを検証する方法を示しています。

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **スレッド安全性**

{{% alert color="warning" title="警告" %}}
[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) メソッドはスレッドセーフではありません。複数スレッドから同時に呼び出す必要がある場合は、`threading.Lock` などの同期プリミティブを使用して問題を回避してください。
{{% /alert %}}

## **FAQ**

### 完全にオフライン環境（インターネット未接続）でライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作を停止しますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。