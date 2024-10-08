---  
title: 转换为PDF  
type: docs  
weight: 30  
url: /net/conversion-to-pdf/  
---  

PDF文档被广泛用作组织、政府部门和个人之间交换文档的标准格式。这是一种流行的格式，因此开发人员常常被要求将Microsoft PowerPoint演示文件转换为PDF文档。为了满足这种可能的需求，Aspose.Slides for .NET支持在不使用任何其他组件的情况下将演示文稿转换为PDF文档。

**Aspose.Slides for .NET**提供了表示演示文稿文件的Presentation类。**Presentation**类暴露了可以调用的Save方法，用于将整个演示文稿转换为**PDF**文档。**PdfOptions**类提供了创建**PDF**的选项，例如JpegQuality、TextCompression、Compliance等。这些选项可以用来获得所需的PDF标准。

```csharp  

 string FilePath = @"..\..\..\Sample Files\";  

string srcFileName = FilePath + "Conversion.pptx";  

string destFileName = FilePath + "Converting to PDF.pdf";  

//实例化表示演示文稿文件的Presentation对象  

Presentation pres = new Presentation(srcFileName);  

//使用默认选项将演示文稿保存为PDF  

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);  

```  
## **下载示例代码**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)  