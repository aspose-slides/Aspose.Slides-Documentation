---
title: Licensing
type: docs
weight: 90
url: /androidjava/licensing/
keywords:
- license
- temporary license
- set license
- use license
- validate license
- license file
- evaluation version
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for Android via Java. Ensure uninterrupted access to full features with our licensing guide."
---

## **Evaluate Aspose.Slides**

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides for Android via Java** from its [download page](https://releases.aspose.com/slides/androidjava/). The evaluation version provides the same functionalities as the licensed version of the product. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to it (to apply the license).

Once you are happy with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/buy). We recommend you go through the different subscription types. If you have questions, contact the Aspose sales team.

Every Aspose license comes with one-year subscription for free upgrades to new versions or fixes released within the subscription period. Users with licensed products (or even evaluation versions) get free and unlimited technical support.

{{% /alert %}} 

**Evaluation version limitations**

* While Aspose.Slides evaluation version (without a license specified) provides full product functionality, it inserts an evaluation watermark at the top of the document on open and save operations. 
* You are limited to one slide when extracting texts from presentation slides.

{{% alert color="primary" %}} 

To test Aspose.Slides without limitations, you can ask for a **30-Day Temporary License**. See the [How to get a Temporary License](https://purchase.aspose.com/temporary-license) page for more information.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to it (to apply the license).
* The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. 
* The license file is digitally signed, so you must not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.
* Aspose.Slides for Android via Java typically tries to find the license in these locations:
  * An explicit path
  * The folder containing Aspose.Slides.jar
* To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You only have to set a license once per application or process.

## **Applying a License**

A license can be loaded from a **file** or **stream**.

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) class for licensing operations.

{{% /alert %}} 

{{% alert color="warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The easiest method of setting a license requires you to place the license file in the folder containing Aspose.Slides.jar or your applications' jar.

This Java code shows you how to set a license file:

``` java
// Instantiates the License class
com.aspose.slides.License license = new com.aspose.slides.License();

// Sets the license file path
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

If you place the license file in a different directory, when you call the [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) method, the license file name at the end of the specified explicit must be the same as your license file.

For example, you can change the license file name to *Aspose.Slides.Android.via.Java.lic.xml*. Then, in your code, you have to pass the path to the file (ending with *Aspose.Slides.Android.via.Java.lic.xml*) to the [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. This Java code shows you how to apply a license from a stream:

``` java
// Instantiates the License class
com.aspose.slides.License license = new com.aspose.slides.License();

// Sets the license through a stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validating a License**

To check whether a license has been set properly, you can validate it. This Java code shows you how to validate a license:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) method is not thread-safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}

## **FAQ**

**Can I apply the license in a completely offline environment (no internet access)?**

Yes. License validation is performed locally using the license file; no internet connection is required.

**What happens after the one-year subscription expires? Will the library stop working?**

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
