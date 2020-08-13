---
title: Using Default Fonts for Rendering Presentation in Python
type: docs
weight: 80
url: /java/using-default-fonts-for-rendering-presentation-in-python/
---

## **Aspose.Slides - Using Default Fonts for Rendering Presentation**
To Use Default Fonts for Rendering Presentation using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Use load options to define the default regualr and asian fonts

loadFormat = LoadFormat

lo = LoadOptions(loadFormat.Auto)

lo.setDefaultRegularFont("Wingdings")

lo.setDefaultAsianFont("Wingdings")

\# Create an instance of Presentation class

pres = Presentation(self.dataDir + 'input.pptx')

\# Generate PDF

save_format = self.SaveFormat

pres.save(self.dataDir + "output.pdf", save_format.Pdf)

print "Done with font family for text, please check the output file."


```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
