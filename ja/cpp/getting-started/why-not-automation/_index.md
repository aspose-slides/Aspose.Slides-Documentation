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
description: "サーバーやサービスにおいて Office の自動化がリスクとなる理由を明らかにし、Aspose.Slides が PowerPoint および OpenDocument 向けに、より安全で高速なプレゼンテーション処理を提供する方法をご紹介します。"
---
## **はじめに**

Aspose コンポーネントが自動化の代替として優れている理由はいくつかあります。主な理由は次のとおりです。

- セキュリティ
- 安定性
- スケーラビリティ/速度
- 価格
- 機能

以下に各ポイントの詳細な説明を示します。

## **重要な質問**
- なぜ Aspose コンポーネントは Microsoft Office Automation よりもはるかに優れた選択肢なのですか？

Aspose で最もよく聞かれる質問は次の 2 つです。

- 製品の実行に Microsoft Office のインストールが必要ですか？

簡潔な答えは **いいえ** です。Aspose と Aspose コンポーネントは完全に独立しており、Microsoft Corporation と提携、認可、スポンサー、または承認されているわけではありません。

- なぜ Microsoft Office Automation を利用するのではなく Aspose 製品を使用すべきなのでしょうか？

最も簡潔な答えは、Microsoft 自体がソフトウェア ソリューションからの Office Automation を強く推奨しないという点です。詳細は以下の Microsoft 記事をご参照ください: [Microsoft Article

## **セキュリティ**
上記の Microsoft 記事からの直接引用です:
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose 製品は非常に安全です。そのため、Aspose コンポーネントは重要なシステムリソースに対する潜在的リスクをもたらしません。さらに、Aspose コンポーネントでドキュメントを開いてもマクロは自動的に実行されません。Aspose コンポーネントは、開発者が Office ファイルを作成、操作、保存できるように設計されています。Microsoft Office パッケージに関連するリスクは Aspose コンポーネントには存在しません。

## **安定性**
上記の Microsoft 記事からの直接引用です:
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Aspose コンポーネントは単一の DLL にパッケージ化されているため、追加の部品やパーツをインストールする必要は一切ありません。Aspose コンポーネントは C++ アプリケーションのみで使用され、人間の応答を待つようなコードは含まれていません。徹底的にテストされており、極めて安定しています。Aspose コンポーネントは、[Companies](https://about.aspose.com/customers) の **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** など多数の企業で利用されています。

## **スケーラビリティ/速度**
上記の Microsoft 記事からの直接引用です:
*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Aspose コンポーネントは高いスケーラビリティと超高速を実現しています。Office アプリケーションは数百〜数千ユーザーが同時に利用するようには設計されていませんが、Aspose コンポーネントはそのようなシナリオを前提に作られています。真の C++ ソリューションとして、単一サーバー上の単一アプリケーションでも、エンタープライズ規模のロードバランス Web フォーム上でも問題なく動作します。

## **価格**
Microsoft Office Automation を利用するアプリケーションでは、実行するマシンごとに Microsoft Office のコピーを購入する必要があります。多くの場合、Office ファイルの作成や操作は必要でも、ユーザーが Microsoft Office を所有している必要はありません。Aspose は非常に **Cost Effective** でロイヤリティフリーの再配布ライセンスを提供しており、ライセンスの心配なく無制限のユーザーに展開できます。Web アプリケーションを作成する際、Microsoft Office Automation コンポーネントはサーバー側ソリューション向けに価格設定やライセンスが提供されていないため、適切なライセンス手段がありません。Aspose はサーバー側アプリケーション向けにも非常に **Cost Effective** なソリューションを提供しています。

## **機能**
Aspose コンポーネントは Office ファイルの管理に必要なすべてを提供し、さらに多くの機能を備えています。開発者が最小限の作業で最大の成果を上げられるよう設計されています。Office Automation とは異なり、Aspose コンポーネントは多くの強力で時間を節約できる機能を提供します。例えば、[Aspose.Cells](https://products.aspose.com/cells/cpp/) は **DataTable** や **DataView** から直接 Excel ファイルへデータをインポートできる機能を提供します。[Aspose.Words](https://products.aspose.com/words/net/) は任意の C++ データオブジェクトから直接 Word（メール マージ）ドキュメントを作成できる類似の機能を提供します。[Every Component](https://products.aspose.com/total/cpp/) はそれぞれ独自のユニークで強力な機能セットを持っています。Aspose コンポーネントを購入すると、開発チームへのアクセスが得られます。お客様が必要とする機能は他の企業でも必要とされる可能性が高く、私たちのチームは可能な限り柔軟に支援します。この姿勢が Aspose コンポーネントを現在のように強力にしています。Office Automation のオブジェクトに追加機能が必要な場合、その機能が追加される可能性は極めて低いです。

## **結論**
{{% alert color="info" %}} 

この記事では、Aspose コンポーネントが Office Automation よりも優れている主要なポイントを多数取り上げましたが、実際にはさらに多くの利点があります。本稿は主に最も重要なポイントに焦点を当てています。すべての Aspose コンポーネントはリスクフリーで無条件の [Evaluation Version](https://downloads.aspose.com/slides/ja/cpp) を提供しています。ぜひこの [Evaluation](https://downloads.aspose.com/slides/ja/cpp) を活用し、Aspose があなたのアプリケーションでどのように役立つかをご確認ください。
{{% /alert %}}