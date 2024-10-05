---
title: 中断可能なライブラリのサポート
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **中断可能なライブラリ**
現在、Aspose.SlidesにInterruptionToken構造体とInterruptionTokenSourceクラスが追加されました。これらの型は、デシリアル化、シリアル化、またはレンダリングなどの長時間実行されるタスクの中断をサポートします。InterruptionTokenSourceは、**ILoadOptions.InterruptionToken**に渡されるトークンまたは複数のトークンのソースを表します。ILoadOptions.InterruptionTokenが設定され、このLoadOptionsインスタンスがPresentationコンストラクターに渡されると、このPresentationに関連する長時間実行されるタスクは、InterruptionTokenSource.Interruptメソッドが呼び出されたときに中断されます。

以下のコードスニペットは、実行中のタスクの中断を示しています。

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}