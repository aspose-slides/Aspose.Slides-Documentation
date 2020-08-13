---
title: Licensing
type: docs
weight: 90
url: /java/licensing/
---

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides** for Java from [its download page](http://maven.aspose.com/repository/simple/ext-release-local/com/aspose/aspose-slides/). The evaluation version provides absolutely the same capabilities as the licensed version of the product. Furthermore, evaluation version simply becomes licensed when you purchase a license and add a couple of lines of code to apply the license.

Once you are happy with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/default.aspx) at the Aspose website. Make yourself familiar with the different subscription types offered. If you have any questions, do not hesitate to contact the Aspose sales team.

Every Aspose license carries a one-year subscription for free upgrades to any new versions or fixes that come out during this time. Technical support is free and unlimited and provided both to licensed and evaluation users.

{{% /alert %}} {{% alert color="primary" %}} 

If you want to test **Aspose.Slides** without evaluation version limitations, request a 30-day temporary license. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}} 
### **Evaluation Version Limitation**
Evaluation version of Aspose.Slides (without a license specified) provides full product functionality except that when you save your presentations using Aspose.Slides, an Evaluation Watermark is injected at the center of each slide as shown in the figure below:

|![todo:image_alt_text](http://i.imgur.com/mk7c8lo.png)|
| :- |
|**Figure: Evaluation Watermark**|
### **Setting a License**
The license is a plain text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. The file is digitally signed, so do not modify the file; even the inadvertent addition of an extra line break into the file will invalidate it.

You need to set a license before utilizing **Aspose.Slides** if you want to avoid its evaluation limitation. You are only required to set a license once per application or process.

The license can be loaded from a stream or file in the following locations:

1. Explicit path.
1. The folder that contains the Aspose.Slides.jar.

Use the [License](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/License).setLicense method to license the component. Often the easiest way to set a license is to put the license file in the same folder as Aspose.Slides.jar and specify just the file name without path as shown in the following example:
#### **Example 1**
In this example Aspose.Slides will attempt to find the license file in the folder that contain the JARs of your application.

**Java**

{{< highlight csharp >}}

 com.aspose.slides.License license = new com.aspose.slides.License();

license.setLicense("Aspose.Slides.Java.lic");

{{< /highlight >}}
#### **Example 2**
Initializes a license from a stream.

**Java**

{{< highlight csharp >}}

 com.aspose.slides.License license = new com.aspose.slides.License();

license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));

{{< /highlight >}}
#### **Setting a License in PHP Using PHP/Java Bridge**
Setting the license in PHP using **PHP/Java Bridge** is similar to **Aspose.Slides for Java**. It is because of the fact that PHP developers actually use the API of **Aspose.Slides for Java** in PHP. **PHP/Java Bridge** provides an interface to the PHP developers that makes it possible to use Java classes in PHP syntax.

[**PHP**](/pages/createpage.action?spaceKey=slidesjava&title=PHP&linkCreation=true&fromPageId=9503253)

{{< highlight csharp >}}

 <?php


	 //Using aspose.slides.jar file so that the classes inside the jar file

	 //can be used

	 java_require("aspose.slides.jar");


	 try

	 {

	   //Create a stream object containing the license file

	   $fistream=new Java("java.io.FileInputStream","C:\\Aspose.Slides.Java.lic");


	   //Instantiate the License class

	   $license=new Java("com.aspose.slides.License");


	   //Set the license through the stream object

	   $license->setLicense($fistream);


	   //Closing the stream

	   $fistream->close();

	 }

	 catch(JavaException $ex)

	 {

	   //Printing the exception, if it occurs

	   echo $ex->toString();

	 }

?>

{{< /highlight >}}
### **Validate the License**
It is possible to validate if the license has been set properly or not. The [License](https://apireference.aspose.com/java/slides/com.aspose.slides/License) class has the isLicensed field that will return true if license has been properly set.

**Java**

{{< highlight csharp >}}

 License license = new License();

license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) {

    System.out.println("License is Set!");

}

{{< /highlight >}}


