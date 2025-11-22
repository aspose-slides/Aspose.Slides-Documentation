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
description: "Aspose.Slides for Python via .NET のライセンスの適用、管理、トラブルシューティング方法を学びます。ステップバイステップのライセンスガイドで、フル機能への継続的なアクセスを確保しましょう。"
---

## **Aspose.Slides を評価する**

**Aspose.Slides for Python via .NET** の評価版は、[ダウンロードページ](https://pypi.org/project/Aspose.Slides/)から入手できます。評価版は製品版と同じ機能を提供します。評価パッケージは購入版と同一で、ライセンスを適用する数行のコードを追加するとライセンスが有効になります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。利用可能なサブスクリプションオプションをご確認ください。ご質問がある場合は、Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、1 年間のサブスクリプションが含まれ、その期間中の新バージョンおよび修正への無料アップグレードが提供されます。ライセンス版・評価版のユーザーは、無料で無制限のテクニカルサポートを受けられます。

**評価版の制限事項**

* Aspose.Slides の評価版（ライセンス未適用）では全機能が利用できますが、ドキュメントを開くまたは保存するたびに、上部に評価用の透かしが追加されます。
* プレゼンテーションからテキストを抽出する場合、1 スライドに制限されます。

{{% alert color="primary" %}}
制限なしで Aspose.Slides を試したい場合は、**30 日間の一時ライセンス**を申請できます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) ページをご覧ください。
{{% /alert %}}

## **Aspose.Slides のライセンス管理**

* 評価版は、ライセンスを購入し、数行のコードで適用すると正式にライセンスが有効になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、対象開発者数、サブスクリプションの有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。1 行の改行でも無効になります。
* Aspose.Slides for Python via .NET は、次の場所でライセンスを検索します。
  * 明示的に指定したパス
  * Aspose.Slides for Python via .NET を呼び出す Python スクリプトが存在するフォルダー
* 評価版の制限を回避するには、Aspose.Slides を使用する前にライセンスを設定してください。アプリケーションまたはプロセスごとに一度設定すれば完了です。

{{% alert color="primary" %}}
[従量課金ライセンス](/slides/ja/python-net/metered-licensing/) もご確認ください。
{{% /alert %}}

## **ライセンスの適用方法**

ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** から読み込めます。

{{% alert color="primary" %}}
Aspose.Slides は、ライセンス管理用に [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) クラスを提供しています。
{{% /alert %}}

{{% alert color="warning" %}}
新しいライセンスはバージョン 21.4 以降でのみ Aspose.Slides を有効化できます。以前のバージョンは別のライセンスシステムを使用しているため、これらのライセンスは認識されません。
{{% /alert %}}

### **ファイル**

最も簡単な方法は、コンポーネントの DLL と同じフォルダーにライセンスファイルを配置し、ファイル名（パスなし）のみを指定することです。

次の Python コードはライセンスファイルの設定方法を示しています:
```py
import aspose.slides as slides

# ライセンス クラスをインスタンス化します。
license = slides.License()

# ライセンス ファイル パスを設定します。
license.set_license("Aspose.Slides.lic")
```


{{% alert color="warning" %}}
ライセンスファイルを別のディレクトリに置く場合、[License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) を呼び出す際に、明示的なパスの最後にあるファイル名が実際のライセンスファイル名と一致している必要があります。

例として、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更し、コード内でそのフルパス（末尾が Aspose.Slides.lic.xml）を [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) に渡してください。
{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードできます。次の Python の例は、ストリームからライセンスを適用する方法を示しています:
```py
import aspose.slides as slides

# ライセンス クラスをインスタンス化します。
license = slides.License()

# ストリームからライセンスを設定します。
license.set_license(stream)
```


## **ライセンスの検証**

ライセンスが正しく適用されたか確認するには、検証を行います。次の Python コードはライセンスの検証方法を示しています:
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **スレッド安全性**

{{% alert title="Note" color="warning" %}}
[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) メソッドはスレッドセーフではありません。複数スレッドから同時に呼び出す必要がある場合は、`threading.Lock` などの同期プリミティブを使用して問題を回避してください。
{{% /alert %}}

## **FAQ**

**完全にオフラインの環境（インターネットアクセスなし）でライセンスを適用できますか？**

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが終了した後はどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永続的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用可能ですが、更新しない限り新しいリリースは利用できません。