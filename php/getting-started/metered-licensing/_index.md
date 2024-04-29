---
title: Metered Licensing
type: docs
weight: 100
url: /java/metered-licensing/
---

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. If you want to be billed based on your usage of Aspose.Slides API features, you choose metered licensing.

When you purchase a metered license, you get keys (and not a license file). This metered key can be applied using the [Metered](https://reference.aspose.com/slides/php-java/com.aspose.slides/metered/) class Aspose provided for metering operations. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Create an instance of the [Metered](https://reference.aspose.com/slides/php-java/com.aspose.slides/metered/) class.

1. Pass your public and private keys to the [setMeteredKey](https://reference.aspose.com/slides/php-java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) method.

1. Do some processing (perform tasks).

1. Call the [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/com.aspose.slides/metered/#getConsumptionQuantity--) method of the Metered class.

   You should see the amount/quantity of API requests you have consumed so far.

This Java code shows you how to set metered public and private keys:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Accesses the setMeteredKey property and pass public and private keys as parameters
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // Gets the consumed qantity value before accessing API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantityOld);


    // Gets the consumed qantity value after accessing API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
