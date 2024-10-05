---  
title: 割り込み可能なライブラリのサポート  
type: docs  
weight: 120  
url: /java/support-for-interruptable-library/  
---  
  
## **割り込み可能なライブラリ**  
現在、Aspose.SlidesにInterruptionToken構造体とInterruptionTokenSourceクラスが追加されました。これらの型は、デシリアライズ、シリアライズ、レンダリングなどの長時間実行されるタスクの割り込みをサポートします。InterruptionTokenSourceは、**ILoadOptions.InterruptionToken**に渡されるトークンまたは複数のトークンのソースを表します。ILoadOptions.InterruptionTokenが設定され、このLoadOptionsインスタンスがPresentationコンストラクターに渡されると、このPresentationに関連する長時間実行されるタスクは、InterruptionTokenSource.Interruptメソッドが呼び出されると割り込まれます。  
  
以下のコードスニペットは、実行中のタスクの割り込みを示しています。  
  
{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}