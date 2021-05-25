---
title: Metered Licensing
type: docs
weight: 100
url: /java/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides allows developers to apply metered key. It is a new licensing mechanism. The new licensing mechanism will be used along with existing licensing method. Those customers who want to be billed based on the usage of the API features can use the metered licensing. For more details, please refer to [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) section.

{{% /alert %}} 
## **Metered Licensing**
Here are the simple steps to use the Metered class.

1. Create an instance of Metered class.
1. Pass public & private keys to setMeteredKey method.
1. Do processing (perform task).
1. call method getConsumptionQuantity of the Metered class.
1. It will return the amount/quantity of API requests that you have consumed so far.

Following is the sample code demonstrating how to set metered public and private key.

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Access the setMeteredKey property and pass public and private keys as parameters
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // Get consumed qantity value before accessing API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantityOld);


    // Get consumed qantity value after accessing API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```




