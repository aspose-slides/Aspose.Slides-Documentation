---  
title: プレゼンテーション画像コレクション内の画像の置換  
type: docs  
weight: 90  
url: /ja/cpp/replacing-images-inside-presentation-image-collection/  
---  

{{% alert color="primary" %}}  

Aspose.Slides for C++では、スライドシェイプに追加された画像を置換することができます。この記事では、異なるアプローチを通じてプレゼンテーション画像コレクション内の画像を置換する方法を学びます。

{{% /alert %}}  
## **プレゼンテーション画像コレクション内の画像の置換**  
Aspose.Slides for C++は、プレゼンテーション画像コレクション内の画像を置換するためのシンプルなAPIメソッドを提供しています。以下の方法で行います:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスを使用して、画像が含まれているプレゼンテーションファイルをロードします。  
1. バイト配列からファイルの画像をロードします。  
1. 次のいずれかのアプローチを使用します:  
   - 最初のアプローチ: ターゲット画像をバイト配列内の新しい画像で置換します。  
   - 2番目のアプローチ: [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image)オブジェクトに画像をロードし、ターゲット画像をロードした画像に置換します。  
   - 3番目のアプローチ: プレゼンテーション画像コレクションに既に追加された画像で画像を置換します。  
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。  

このサンプルコードは、プレゼンテーション画像コレクション内の画像を置換する方法を示しています:  

``` cpp  
// プレゼンテーションをインスタンス化  
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");  

// 最初のアプローチ  
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");  
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);  
oldImage->ReplaceImage(data);  

// 2番目のアプローチ  
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");  
oldImage = presentation->get_Images()->idx_get(1);  
oldImage->ReplaceImage(newImage);  
newImage->Dispose();  

// 3番目のアプローチ  
oldImage = presentation->get_Images()->idx_get(2);  
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));  

// プレゼンテーションを保存  
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);  
```  
