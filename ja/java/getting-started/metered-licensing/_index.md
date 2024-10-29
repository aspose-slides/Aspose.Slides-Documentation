---  
title: 従量課金ライセンス  
type: docs  
weight: 100  
url: /ja/java/metered-licensing/  
---  

{{% alert color="primary" %}}  

従量課金ライセンスは、既存のライセンス方法と併用できる新しいライセンスメカニズムです。Aspose.Slides APIの機能の使用量に基づいて請求されることを希望する場合は、従量課金ライセンスを選択します。  

従量課金ライセンスを購入すると、キー（ライセンスファイルではなく）が提供されます。この従量課金キーは、Asposeが計測操作用に提供した[Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/)クラスを使用して適用できます。詳細については、[従量課金ライセンスFAQ](https://purchase.aspose.com/faqs/licensing/metered)を参照してください。  

{{% /alert %}}  
1. [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/)クラスのインスタンスを作成します。  

1. あなたの公開キーと秘密キーを、[setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)メソッドに渡します。  

1. 一部の処理を行います（タスクを実行します）。  

1. Meteredクラスの[getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--)メソッドを呼び出します。  

   これまでに消費したAPIリクエストの量/量が表示されるはずです。  

このJavaコードは、従量課金の公開キーと秘密キーを設定する方法を示しています：  

```java  
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();  
try {  
    // setMeteredKeyプロパティにアクセスし、公開キーと秘密キーをパラメータとして渡します  
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");  

    // APIにアクセスする前の消費量値を取得します  
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("消費量" + quantityOld);  


    // APIにアクセスした後の消費量値を取得します  
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("消費量" + quantity);  
} catch (Exception ex) {  
    ex.printStackTrace();  
}  
```  

{{% alert color="warning" title="注意"  %}}  

従量課金ライセンスを使用するには、ライセンスメカニズムがインターネットを使用して私たちのサービスと常にやり取りし、計算を行うため、安定したインターネット接続が必要です。  

{{% /alert %}}  