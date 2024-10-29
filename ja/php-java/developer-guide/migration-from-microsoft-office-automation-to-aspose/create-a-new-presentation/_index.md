---
title: 新しいプレゼンテーションを作成する
type: docs
weight: 10
url: /ja/php-java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTOは、開発者がMicrosoft Office内で実行できるアプリケーションを構築できるように開発されました。VSTOはCOMベースですが、.NETオブジェクト内にラップされているため、.NETアプリケーションで使用できます。VSTOには.NETフレームワークのサポートとMicrosoft Office CLRベースのランタイムが必要です。Microsoft Officeアドインを作成するために使用することはできますが、サーバーサイドコンポーネントとして使用することはほぼ不可能です。また、深刻な展開の問題があります。

Aspose.Slides for PHP via Javaは、Microsoft PowerPointプレゼンテーションを操作するために使用できるコンポーネントであり、VSTOと同様ですが、いくつかの利点があります：

- Aspose.Slidesは管理コードのみを含んでおり、Microsoft Officeランタイムをインストールする必要がありません。
- クライアントサイドコンポーネントまたはサーバーサイドコンポーネントとして使用できます。
- Aspose.Slidesは単一のjarファイル内に含まれているため、展開が簡単です。

{{% /alert %}} 
## **プレゼンテーションの作成**
以下は、VSTOとAspose.Slides for PHP via Javaを使用して同じ目的を達成する方法を示す2つのコード例です。最初の例は[VSTO](/slides/ja/php-java/create-a-new-presentation/)であり、[2番目の例](/slides/ja/php-java/create-a-new-presentation/)はAspose.Slidesを使用しています。
### **VSTOの例**
**VSTOの出力** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for PHP via Javaの例**
**Aspose.Slidesからの出力** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}