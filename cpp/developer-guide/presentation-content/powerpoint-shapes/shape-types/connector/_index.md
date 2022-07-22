---
title: Connector
type: docs
weight: 10
url: /cpp/connector/
---


## **Connect Shapes using Connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Call Reroute() method to create the shortest automatic connection path.
1. Write the `Presentation` as a PPTX file.
   In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectShapesUsingConnectors-ConnectShapesUsingConnectors.cpp" >}}

## **Use Desired Connection Site**
{{% alert color="primary" %}} 

Method IConnector.Reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 

In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Setting the desired connection site on shape for a connector.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectShapeUsingConnectionSite-ConnectShapeUsingConnectionSite.cpp" >}}


## **Find Angle of Connector Lines**
In order to calculate the angle for the connector line, please follow the steps below:

1. Create an instance of `Presentation` class and load the presentation.
1. Obtain the reference of a slide by using its Index.
1. Access the Connector Line shape.
1. Use the line width, height, shape frame height and shape frame width to calculate the angle.
   In the example given below, we have calculated the angle for connector line shape in a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectorLineAngle-ConnectorLineAngle.cpp" >}}


