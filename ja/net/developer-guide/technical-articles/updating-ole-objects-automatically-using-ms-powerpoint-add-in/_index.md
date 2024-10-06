---  
title: MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新  
type: docs  
weight: 10  
url: /ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/  
---  

## **OLE オブジェクトを自動的に更新するについて**  
Aspose.Slides for .NET の顧客から最もよく寄せられる質問の一つは、編集可能なチャートまたは他の OLE オブジェクトを作成または変更し、プレゼンテーションを開くときにそれらを自動的に更新する方法です。残念ながら、PowerPoint は Excel や Word で利用可能な自動マクロをサポートしていません。利用できるのは Auto_Open と Auto_Close のマクロだけです。ただし、これらはアドインから自動的に実行されるのみです。この短い技術的ヒントは、それを実現する方法を示します。 

まず、Auto_Open マクロ機能を PowerPoint に追加するいくつかのフリーウェアアドインが利用可能です。たとえば [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) と [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html) です。 

そのようなアドインをインストールした後、以下に示すように、テンプレートプレゼンテーションに Auto_Open() マクロ（「Event Generator」の場合は OnPresentationOpen()）を追加します。 

```c#  
public void Auto_Open()  
{  
    Shape oShape;  
    Slide oSlide;  
    object oGraph;  

    // プレゼンテーション内の各スライドをループします。  
    foreach (var oSlide in ActivePresentation.Slides)  
    {  

        // 現在のスライド上のすべての形状をループします。  
        foreach (var oShape in oSlide.Shapes)  
        {  

            // 形状が OLE オブジェクトかどうかを確認します。  
            if (oShape.Type == msoEmbeddedOLEObject)  
            {  

                // OLE オブジェクトを見つけた; オブジェクト参照を取得し、その後更新します。  
                oObject = oShape.OLEFormat.Object;  
                oObject.Application.Update();  

                // さて、OLE サーバープログラムを終了します。これにより  
                // メモリが解放され、問題が防止されます。また、oObject を Nothing に設定して  
                // オブジェクトを解放します。  
                oObject.Application.Quit();  
                oObject = null;  
            }  
        }  
    }  
}  
```  

{{% alert color="primary" %}}  

Aspose.Slides for .NET を使用して OLE オブジェクトに加えられた変更は、PowerPoint がプレゼンテーションを開くときに自動的に更新されます。プレゼンテーションに多くの OLE オブジェクトがあり、それらすべてを更新したくない場合は、処理する必要がある形状にカスタムタグを追加し、マクロでチェックしてください。  

{{% /alert %}}  