---
title: なぜ自動化ではないのか
type: docs
weight: 50
url: /ja/cpp/why-not-automation/
keywords:
- 自動化
- Microsoft Office
- 比較
- セキュリティ
- 安定性
- スケーラビリティ
- 機能
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "サーバーやサービスにおいて Office 自動化がリスクが高い理由を発見し、PowerPoint と OpenDocument 向けに Aspose.Slides が提供する、より安全で高速なプレゼンテーション処理をご覧ください。"
---
## **イントロダクション**

Aspose コンポーネントが自動化よりも優れた代替手段である理由はいくつかあります。主な理由は次のとおりです。

- セキュリティ
- 安定性
- スケーラビリティ/速度
- 価格
- 機能

以下に、各重要ポイントの詳細な説明を示します。

## **重要な質問**
- Aspose コンポーネントは、Microsoft Office Automation に比べてはるかに優れた選択肢である理由は何ですか？

Aspose で最もよく聞かれる質問は次の 2 つです。

- 製品の実行に Microsoft Office のインストールが必要ですか？

簡潔な答えは **NO** です。Aspose と Aspose コンポーネントは完全に独立しており、Microsoft Corporation と提携、認可、スポンサー、または承認されているわけではありません。

- Microsoft Office Automation を利用するよりも Aspose 製品を使用すべき理由は何ですか？

最も簡単に答えると、Microsoft 自体がソフトウェアソリューションによる Office Automation を強く推奨しないという点が最大の理由です: [Microsoft Article

## **セキュリティ**
上記参照の Microsoft Article からの直接引用は次のとおりです： 
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose 製品は非常に安全です。したがって、Aspose コンポーネントは重要なシステムリソースに対する潜在的なリスクをもたらしません。さらに、Aspose コンポーネントでドキュメントを開く際、マクロは自動的に実行されません。Aspose コンポーネントは、開発者が Office ファイルを作成、操作、保存できるように設計されています。Microsoft Office パッケージに関連するリスクは Aspose コンポーネントには存在しません。

## **安定性**
上記参照の Microsoft Article からの直接引用は次のとおりです： 
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Aspose コンポーネントは単一の DLL にパッケージ化されているため、追加の部品やパーツをインストールする必要はありません。Aspose コンポーネントは C++ アプリケーションでのみ使用され、人間の応答を待つようなコードは含まれていません。徹底的にテストされており、極めて安定しています。Aspose コンポーネントは[企業](https://about.aspose.com/customers)で使用されており、**IBM**、**Hilton**、**Reader's Digest**、**Bank of America** など多数の企業が採用しています。

## **スケーラビリティ/速度**
上記参照の Microsoft Article からの直接引用は次のとおりです：

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Aspose コンポーネントは高いスケーラビリティと極めて高速です。Office アプリケーションは数百～数千ユーザーが同時に使用するようには設計されていませんが、Aspose コンポーネントはそのようなシナリオを想定して設計されています。当社のコンポーネントは純粋な C++ ソリューションであり、単一サーバー上の単一アプリケーションでも、エンタープライズ規模のロードバランスされた Web フォーム上でも、問題なく動作します。

## **価格**
Microsoft Office Automation を利用する場合、アプリケーションを実行する各マシンに Microsoft Office のコピーを購入しなければなりません。多くの場合、アプリケーションは Office ファイルの作成や操作が必要ですが、ユーザーに Microsoft Office がインストールされている必要はありません。Aspose は非常に[コスト効率が高く](https://purchase.aspose.com/)、ロイヤリティフリーの再配布ライセンスを提供しており、無制限のユーザー数に対してライセンスの心配なく展開できます。Web ベースのアプリケーションを作成する際、Microsoft Office Automation コンポーネントはサーバー側ソリューション向けに価格設定やライセンスが行われていないため、適切なライセンス形態がありません。Aspose はサーバー側アプリケーション向けにも非常に[コスト効率が高い](https://purchase.aspose.com/) ソリューションを提供しています。

## **機能**
Aspose コンポーネントは Office ファイルの管理に必要なすべてを提供し、さらに多くの機能を備えています。開発者が最小限の作業で最大の成果を上げられるよう設計されています。Office Automation とは異なり、Aspose コンポーネントは多数の強力かつ時間節約できる機能を提供します。たとえば、[Aspose.Cells](https://products.aspose.com/cells/cpp/) は **DataTable** や **DataView** から直接 Excel ファイルへデータをインポートできます。[Aspose.Words](https://products.aspose.com/words/net/) は C++ の任意のデータオブジェクトから直接 Word（メール マージ）ドキュメントを生成する機能を提供します。[すべてのコンポーネント](https://products.aspose.com/total/cpp/) がそれぞれ固有の強力な機能を持っています。Aspose コンポーネントを購入する最大のメリットは、当社の開発チームへのアクセスです。お客様の企業が必要とする機能は、他の企業でも必要とされる可能性が高いと当社は認識しています。すべての機能要望を実装できるわけではありませんが、当社チームはできる限り柔軟に支援する姿勢を持っています。この考え方が Aspose コンポーネントを現在のように強力にしています。Office Automation のオブジェクトから追加機能が必要な場合でも、その実装が追加される可能性は極めて低いです。

## **結論**
{{% alert color="primary" %}} 

この記事では、Aspose コンポーネントが Office Automation より優れた選択肢である主な理由を多数取り上げましたが、実際にはさらに多くの利点があります。本稿では最も重要なポイントのみを扱っています。すべての Aspose コンポーネントはリスクフリーで、無償の[評価版](https://downloads.aspose.com/slides/ja/cpp) を提供しています。ぜひその[評価版](https://downloads.aspose.com/slides/ja/cpp) を活用し、Aspose がアプリケーションにもたらす効果をご確認ください。
{{% /alert %}}