---
title: "自動化はなぜ不適切か"
type: docs
weight: 170
url: /ja/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "サーバーやサービスにおける Office 自動化のリスクを理解し、Aspose.Slides が PowerPoint および OpenDocument のプレゼンテーション処理をより安全かつ高速に提供する方法をご覧ください。"
---
## **導入**

Aspose コンポーネントが自動化の代替として優れている理由はいくつかあります。主な理由は次のとおりです：

- セキュリティ
- 安定性
- スケーラビリティ/速度
- 価格
- 機能

以下に各ポイントの詳細な説明を示します。

## **重要な質問**

Aspose でよく聞かれる質問が 2 つあります：

- 製品を実行するために Microsoft Office のインストールが必要ですか？

  簡潔な回答は **NO** です。

  Aspose コンポーネントは完全に独立しており、Microsoft Corporation と提携、認可、スポンサー、またはその他の形で承認されているわけではありません。

- Microsoft Office Automation の代わりに Aspose 製品を使用すべき理由は？

  まず、Aspose.Slides を使用する際の利点が多くあります。[Aspose.Slides を使用する際の利点](/slides/ja/java/product-overview/)。

  次に、Microsoft 自体がソフトウェア ソリューションから Office Automation の使用を強く **advises against** しています。

## **セキュリティ**

以下は Microsoft の記事からの直接引用です：

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose 製品は非常に安全です。Aspose コンポーネントは重要なシステムリソースに対する潜在的なリスクをもたらしません。さらに、Aspose コンポーネントでドキュメントを開いた際にマクロが自動的に実行されることはありません。Aspose コンポーネントは、開発者が Office ファイルを作成、操作、保存できるように設計されています。Microsoft Office パッケージに伴うリスクは Aspose コンポーネントには固有ではありません。

## **安定性**

以下は Microsoft の記事からの直接引用です：

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Aspose コンポーネントは徹底的にテストされており、非常に安定しています。Aspose コンポーネントは[企業](https://about.aspose.com/customers/)で **Bank of America** をはじめとする多数で使用されています。

## **スケーラビリティ/速度**

以下は Microsoft の記事からの直接引用です：

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*"

Aspose コンポーネントは高度にスケーラブルであり、 lightning fast です。Office アプリケーションは数百、数千人のユーザーが同時に使用するようには設計されていません。しかし、Aspose コンポーネントはそのために設計されています。単一サーバーで単一アプリケーションを駆動する場合でも、負荷分散された Web サーバーファームで企業全体のアプリケーションを駆動する場合でも、コンポーネントは完璧に機能します。

## **価格**

Microsoft Office Automation を利用するアプリケーションでは、アプリケーションを実行する各マシンに対して Microsoft Office のコピーを購入する必要があります。多くの場合、アプリケーションは Office ファイルを作成または操作する必要がありますが、ユーザーが Microsoft Office を所有している必要はありません。Aspose は非常に[Cost Effective](https://purchase.aspose.com/)でロイヤリティフリーの再配布ライセンスを提供しており、ライセンスに関する心配なく無制限のユーザーに展開できます。

Web ベースのアプリケーションを作成する際には、Microsoft Office Automation コンポーネントはサーバーサイドソリューション向けに価格設定やライセンスが行われていないため、Microsoft Office コンポーネントを使用した Web アプリケーションの展開に適したライセンスソリューションはありません。Aspose はサーバー側アプリケーション向けにも非常に Cost Effective なソリューションを提供しています。

## **機能**

Aspose コンポーネントは Office ファイルの管理に必要なすべてを提供し、さらに多くの機能を備えています。開発者が最小限の作業で最大の成果を上げられるように設計されています。Office Automation とは異なり、Aspose コンポーネントは多くの強力で時間節約になる機能を提供します。たとえば、[Aspose.Cells](https://products.aspose.com/cells/java/) は開発者が **DataTable** または **DataView** から直接 Excel ファイルにデータをインポートできる機能を提供します。[Aspose.Words](https://products.aspose.com/words/java/) は同様の機能で、Word（Mail Merge）ドキュメントにデータを埋め込むことができます。[Every Component](https://products.aspose.com/total/java/) はそれぞれ独自のユニークで強力な機能を提供します。

Aspose コンポーネント（または [Aspose.Total](https://products.aspose.com/total/java/) のようなコンポーネントスイート）を購入する最大の利点は、開発チームへのアクセスが得られることです。開発チームは、お客様の会社が必要とする機能は他社でも必要とされる可能性が高いと認識しています。すべての機能要求が追加できるわけではありませんが、チームは支援を提供する際に非常にオープンマインドで柔軟に対応しようと努めています。この考え方が Aspose コンポーネントを現在のように強力にしています。Office Automation オブジェクトから追加機能が必要な場合でも、実装される可能性は極めて低いです。

## **結論**
{{% alert color="info" title="Note" %}}
この文章では Aspose コンポーネントが Office Automation よりも優れた選択肢である主なポイントを多数取り上げましたが、実際にはさらに多くの利点があります。本稿は最も重要なポイントに絞って説明しています。すべての Aspose コンポーネントはリスクフリーで無条件の[Evaluation Version](https://releases.aspose.com/slides/ja/java/) を提供しています。ぜひ Evaluation を活用し、Aspose がアプリケーションにもたらす効果をご確認ください。
{{% /alert %}}